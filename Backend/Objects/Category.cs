//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Drawing;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Color Color { get; set; }
        public virtual double Tax { get; set; }

        public override string ToString()
        {
            return $"Category[ID={Id}, Name={Name}, Color={Color}, Tax={Tax}]";
        }
    }
}