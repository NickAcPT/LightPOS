// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

namespace NickAc.LightBank.Backend.Objects
{
    public class Card
    {
        public virtual int Id { get; set; }

        public virtual string CardSerialNumber { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual User Owner { get; set; }
    }
}