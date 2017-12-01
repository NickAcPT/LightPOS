//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NHibernate;
using NickAc.LightPOS.Backend.Objects;
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

        public static void AddCategory(Category c)
        {
            using (var sf = DataFactory.CreateSessionFactory()) {
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
            using (var sf = DataFactory.CreateSessionFactory()) {
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
            using (var sf = DataFactory.CreateSessionFactory()) {
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
            using (var sf = DataFactory.CreateSessionFactory()) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        if (!NHibernateUtil.IsInitialized(user.Sales))
                            NHibernateUtil.Initialize(user.Sales);
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
            using (var sf = DataFactory.CreateSessionFactory()) {
                using (var session = sf.OpenSession()) {
                    customer = session.QueryOver<Customer>().Where(x => x.ID == id).List().FirstOrDefault();
                    return customer;
                }
            }
        }

        public static Product GetProduct(int id)
        {
            Product product;
            using (var sf = DataFactory.CreateSessionFactory()) {
                using (var session = sf.OpenSession()) {
                    product = session.QueryOver<Product>().Where(x => x.ID == id).List().FirstOrDefault();
                    return product;
                }
            }
        }

        public static Product GetProduct(string barcode)
        {
            Product product;
            using (var sf = DataFactory.CreateSessionFactory()) {
                using (var session = sf.OpenSession()) {
                    product = session.QueryOver<Product>().Where(x => x.Barcode == barcode).List().FirstOrDefault();
                    return product;
                }
            }
        }

        public static IList<Product> GetProducts()
        {
            IList<Product> list;
            using (var sf = DataFactory.CreateSessionFactory()) {
                using (var session = sf.OpenSession()) {
                    list = session.QueryOver<Product>().List();
                }
            }
            return list;
        }

        public static void Initialize(FileInfo file)
        {
            DataFactory = new DataFactory(file, false);
            DataFactory.Create();
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
            using (var sf = DataFactory.CreateSessionFactory()) {
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
            using (var sf = DataFactory.CreateSessionFactory()) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.Delete(p);
                        trans.Commit();
                    }
                }
            }
        }
        public static void RemoveProduct(int productID)
        {
            using (var sf = DataFactory.CreateSessionFactory()) {
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