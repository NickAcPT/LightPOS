//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GNU LGPLv3 License. See LICENSE file in the project root for full license information.
//  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;
using NickAc.LightPOS.Backend.Utils;

namespace NickAc.LightPOS.Backend.Data
{
    public static class DbItemExtensionMethods
    {
        public static void InsertOrUpdate(this BaseDbItem item)
        {
            using (DataManager.SessionFactory.OpenSessionWithTransaction(out var session))
            {
                session.SaveOrUpdate(item);
            }
        }

        public static void Delete<T>(this T item) where T : BaseDbItem
        {
            using (DataManager.SessionFactory.OpenSessionWithTransaction(out var session))
            {
                var exists = session.Query<T>()
                    .Where(x => x.Id == item.Id)
                    .Select(x => x.Id)
                    .Any();
                if (!exists)
                    throw new NotSupportedException("Unable to delete a non-existing item!");

                //Mark as deleted
                item.Deleted = true;
                session.Update(item);
            }
        }

        public static T GetById<T>(long id) where T : BaseDbItem
        {
            using (DataManager.SessionFactory.OpenSessionWithTransaction(out var session))
            {
                return session.Get<T>(id);
            }
        }

        public static IList<T> GetAll<T>() where T : BaseDbItem
        {
            return DataManager.GetAll<T>();
        }

        public static bool CheckNonColliding<T, TProperty>(this T item, Expression<Func<T, TProperty>> propertyLambda)
            where T : BaseDbItem
        {
            var prop = propertyLambda.GetPropertyInfo();
            var originalVal = prop.GetValue(item);

            var anyMatch = GetAll<T>().Where(x => x.Id != item.Id).Select(x1 => prop.GetValue(x1)).Aggregate(false, (current, o) => current | o.Equals(originalVal));

            return !anyMatch;
        }

        public static bool CheckNonColliding<T, TProperty>(this T item, Expression<Func<T, TProperty>> propertyLambda,
            string errorIfMatching, out string error) where T : BaseDbItem
        {
            var result = item.CheckNonColliding(propertyLambda);
            error = result ? null : errorIfMatching;
            return result;
        }
    }
}