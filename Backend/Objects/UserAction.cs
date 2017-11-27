using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Objects
{
    public class UserAction
    {
        public enum Action
        {
            Login,
            LogOut,
            UserSale
        }
        public virtual int ID { get; set; }
        public virtual Action Event { get; set; }
        public virtual String Description { get; set; }
    }
}
