//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Collections.Generic;

namespace NickAc.LightPOS.Backend.Objects
{
    public class Sale
    {
        public virtual int Id { get; set; }

        public virtual IList<Product> Products { get; set; }

        public virtual decimal TotalPrice { get; set; }

        public virtual decimal PaidPrice { get; set; }

        public virtual decimal ChangePrice { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual User User { get; set; }
    }
}