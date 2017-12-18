//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NHibernate;
using NickAc.LightPOS.Backend.Objects;
using NickAc.LightPOS.Backend.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NickAc.LightPOS.Backend.Data
{
    public static class DataManager
    {
        #region Properties

        public static DataFactory DataFactory { get; set; }

        #endregion

        #region Methods
        public static ISessionFactory SessionFactory { get; set; }
        public static void AddCategory(Category c)
        {
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.SaveOrUpdate(c);
                        trans.Commit();
                    }
                }
            }
        }

        public static void AddProduct(Product p)
        {
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.SaveOrUpdate(p.Category);
                        session.SaveOrUpdate(p);
                        trans.Commit();
                    }
                }
            }
        }

        public static void AddSale(Sale s)
        {
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        if (!NHibernateUtil.IsInitialized(s.Customer.Sales))
                            NHibernateUtil.Initialize(s.Customer.Sales);
                        s.Customer.Sales.Add(s);
                        session.SaveOrUpdate(s.User);
                        session.SaveOrUpdate(s.Customer);
                        session.SaveOrUpdate(s);
                        trans.Commit();
                    }
                }
            }
        }

        public static void AddUser(User user)
        {
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        try {
                            if (!NHibernateUtil.IsInitialized(user.Actions))
                                NHibernateUtil.Initialize(user.Actions);
                            if (!NHibernateUtil.IsInitialized(user.Sales))
                                NHibernateUtil.Initialize(user.Sales);
                        } catch (HibernateException) {
                        }
                        session.SaveOrUpdate(user);
                        trans.Commit();
                    }
                }
            }
        }


        public static float CalculateTotal(IList<Product> products)
        {
            float total = 0.0f;
            products.All(p => {
                total += p.Price;
                return true;
            });
            return total;
        }

        public static Sale CreateSale(Customer customer, User user, float paidPrice, params Product[] prods)
        {
            float total = CalculateTotal(prods);
            var finalSale = new Sale
            {
                TotalPrice = total,
                PaidPrice = paidPrice,
                ChangePrice = paidPrice - total,
                Products = prods,
                Customer = customer,
                User = user
            };
            if (!NHibernateUtil.IsInitialized(user.Sales))
                NHibernateUtil.Initialize(user.Sales);
            user.Sales.Add(finalSale);
            return finalSale;
        }


        public static Customer GetCustomer(int id)
        {
            Customer customer;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    customer = session.QueryOver<Customer>().Where(x => x.ID == id).List().FirstOrDefault();
                    return customer;
                }
            }
        }

        public static int GetNumberOfUsers()
        {
            int userNumber;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    userNumber = session.QueryOver<User>().ToRowCountQuery().FutureValue<int>().Value;
                }
            }
            return userNumber;
        }

        public static IList<User> GetUsers()
        {
            IList<User> list;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    list = session.QueryOver<User>().List();
                }
            }
            return list;
        }

        public static User GetUser(int ID)
        {
            User user;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    user = session.QueryOver<User>().Fetch(u => u.Actions)
                  .Eager.Where(u => u.UserID == ID).List().FirstOrDefault();
                }
            }
            return user;
        }


        public static User GetUserComplete(int ID)
        {
            User user;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    user = session
                        .QueryOver<User>()
                        .Fetch(u => u.Sales).Eager
                        .Fetch(u => u.Actions).Eager
                        .Where(u => u.UserID == ID)
                        .List()
                        .FirstOrDefault();
                }
            }
            return user;
        }


        public static IList<User> GetUsersWithSales()
        {
            IList<User> users;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    users = session
                        .QueryOver<User>()
                        .Fetch(u => u.Sales).Eager
                        .List();
                }
            }
            return users;
        }



        public static User GetUserWithActions(int ID)
        {
            User user;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    user = session
                        .QueryOver<User>()
                        .Fetch(u => u.Actions).Eager
                        .Where(u => u.UserID == ID)
                        .List()
                        .FirstOrDefault();
                }
            }
            return user;
        }


        public static User GetUserWithSales(int ID)
        {
            User user;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    user = session
                        .QueryOver<User>()
                        .Fetch(u => u.Sales).Eager
                        .Where(u => u.UserID == ID)
                        .List()
                        .FirstOrDefault();
                }
            }
            return user;
        }


        public static IList<User> GetUsersWithActions()
        {
            IList<User> users;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    users = session
                        .QueryOver<User>()
                        .Fetch(u => u.Actions).Eager
                        .List();
                }
            }
            return users;
        }

        public static void LogAction(User user, UserAction.Action eventAction, string info)
        {
            User freshUser = GetUser(user.UserID);
            UserAction action = new UserAction()
            {
                Time = DateTime.Now,
                Event = eventAction,
                Description = info
            };
            freshUser.Actions.Add(action);

            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.SaveOrUpdate(action);
                        if (!NHibernateUtil.IsInitialized(freshUser.Actions))
                            NHibernateUtil.Initialize(freshUser.Actions);
                        session.SaveOrUpdate(freshUser);
                        trans.Commit();
                    }
                }
            }

        }

        public static Product GetProduct(int id)
        {
            Product product;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    product = session.QueryOver<Product>().Where(x => x.ID == id).List().FirstOrDefault();
                    return product;
                }
            }
        }

        public static Product GetProduct(string barcode)
        {
            Product product;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    product = session.QueryOver<Product>().Where(x => x.Barcode == barcode).List().FirstOrDefault();
                    return product;
                }
            }
        }

        public static IList<Product> GetProducts()
        {
            IList<Product> list;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    list = session.QueryOver<Product>().List();
                }
            }
            return list;
        }

        public static void Initialize(FileInfo file)
        {
            TimeMeasurer.MeasureTime("new DataFactory();", () => {
                if (DataFactory == null) DataFactory = new DataFactory(file, false);
            });
            TimeMeasurer.MeasureTime("DataFactory.Create();", () => {
                if (DataFactory != null) DataFactory.Create();
            });

            if (SessionFactory == null) SessionFactory = DataFactory.CreateSessionFactory();
        }
        /// <summary>
        /// Never called! Exists just to tell Visual Studio to copy the assemblies to the build directory
        /// </summary>
        public static void InitStuff()
        {
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.Dispose();
        }

        public static void RemoveCategory(Category c)
        {
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.Delete(c);
                        trans.Commit();
                    }
                }
            }
        }
        public static void RemoveProduct(Product p)
        {
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.Delete(p);
                        trans.Commit();
                    }
                }
            }
        }


        public static void RemoveUser(User u)
        {
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.Delete(u);
                        trans.Commit();
                    }
                }
            }
        }

        public static void RemoveUserSales(User u)
        {
            if (u.Sales.Count == 0) return;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        u.Sales.All((x) => {
                            session.Delete(x);
                            return true;
                        });
                        trans.Commit();
                    }
                }
            }
        }
        public static void RemoveUserActions(User u)
        {
            if (u.Actions.Count == 0) return;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        u.Actions.All((x) => {
                            session.Delete(x);
                            return true;
                        });
                        trans.Commit();
                    }
                }
            }
        }


        public static void RemoveUser(int userID)
        {
            User finalUser1 = GetUserWithActions(userID);
            User finalUser2 = GetUserWithSales(userID);
            RemoveUser(finalUser1);
        }

        public static void RemoveProduct(int productID)
        {
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.Delete("from Product p where p.ID = ?", productID, NHibernateUtil.Int32);
                        trans.Commit();
                    }
                }
            }
        }

        #endregion
    }
}