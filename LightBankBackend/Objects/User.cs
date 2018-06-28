// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace NickAc.LightBank.Backend.Objects
{
    public class User
    {
        public virtual int Id { get; set; }
        
        public virtual string Name { get; set; }
        
        public virtual IList<Transaction> Transactions { get; set; }

        public virtual IList<Card> Cards { get; set; }

    }
}