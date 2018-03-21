//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace NickAc.LightPOS.Backend.Utils
{
    public static class EnumUtils
    {
        #region Classes

        [AttributeUsage(AttributeTargets.Field)]
        public class DescriptionAttribute : Attribute
        {
            #region Constructors

            public DescriptionAttribute(string description)
            {
                Description = description;
            }

            #endregion

            #region Properties

            public string Description { get; set; }

            #endregion
        }

        #endregion

        #region Methods

        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }

        public static List<T> SplitFlags<T>(this Enum val) where T : struct
        {
            var result = new List<T>();
            foreach (Enum r in Enum.GetValues(val.GetType()))
                if (val.HasFlag(r))
                    result.Add((T) Enum.Parse(typeof(T), r.ToString()));
            return result;
        }

        public static bool HasDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            return attributes != null &&
                   attributes.Length > 0;
        }

        //Code taken from StackOverflow Answer (https://stackoverflow.com/questions/24172370/operator-cannot-be-applied-to-operands-of-type-system-enum-and-system-enu)
        //All credits go to DLeh(https://stackoverflow.com/users/526704/dleh)
        public static Enum And(this Enum a, Enum b)
        {
            // consider adding argument validation here
            if (Enum.GetUnderlyingType(a.GetType()) != typeof(ulong))
                return (Enum) Enum.ToObject(a.GetType(), Convert.ToInt64(a) & Convert.ToInt64(b));
            return (Enum) Enum.ToObject(a.GetType(), Convert.ToUInt64(a) & Convert.ToUInt64(b));
        }

        //Code taken from StackOverflow Answer (https://stackoverflow.com/questions/24172370/operator-cannot-be-applied-to-operands-of-type-system-enum-and-system-enu)
        //All credits go to DLeh(https://stackoverflow.com/users/526704/dleh)
        public static Enum Not(this Enum a)
        {
            // consider adding argument validation here
            return (Enum) Enum.ToObject(a.GetType(), ~Convert.ToInt64(a));
        }

        //Code taken from StackOverflow Answer (https://stackoverflow.com/questions/24172370/operator-cannot-be-applied-to-operands-of-type-system-enum-and-system-enu)
        //All credits go to DLeh(https://stackoverflow.com/users/526704/dleh)
        public static Enum Or(this Enum a, Enum b)
        {
            // consider adding argument validation here
            if (Enum.GetUnderlyingType(a.GetType()) != typeof(ulong))
                return (Enum) Enum.ToObject(a.GetType(), Convert.ToInt64(a) | Convert.ToInt64(b));
            return (Enum) Enum.ToObject(a.GetType(), Convert.ToUInt64(a) | Convert.ToUInt64(b));
        }

        #endregion
    }
}