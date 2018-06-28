// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

namespace NickAc.LightBank.Backend.Objects
{
    public class Transaction
    {
        public virtual int Id { get; set; }

        public virtual User UserFrom { get; set; }

        public virtual User UserTo { get; set; }

        public virtual decimal Value { get; set; }
    }
}