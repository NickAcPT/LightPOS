//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using System;
using System.Drawing;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Category
    {
        public virtual Int32 ID { get; set; }
        public virtual String Name { get; set; }
        public virtual Color Color { get; set; }

        public override string ToString()
        {
            return string.Format("Category[ID={0}, Name={1}, Color={2}]", ID, Name, Color);
        }
    }
}