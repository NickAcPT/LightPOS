//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using NickAc.LightPOS.Backend.Objects;
using System;

namespace NickAc.LightPOS.Frontend.Controls
{
    public partial class UserPanel
    {
        public class UserEventArgs : EventArgs
        {
            public UserEventArgs(User user)
            {
                User = user;
            }

            public User User { get; set; }
        }
    }
}