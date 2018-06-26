// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

namespace NickAc.LightPOS.Backend.Objects
{
    public class UserCard
    {
        public UserCard(string cardId)
        {
            CardId = cardId;
        }

        public virtual string CardId { get; set; }
    }
}