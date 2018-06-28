//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace NickAc.LightPOS.Backend.Objects
{
    public class Category
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual decimal Tax { get; set; }

        public override string ToString()
        {
            return $"Category[ID={Id}, Name={Name}, Tax={Tax}]";
        }
    }
}