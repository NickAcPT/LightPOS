//  
// Copyright (c) NickAc. All rights reserved.
// Licensed under the GNU LGPLv3 License. See LICENSE file in the project root for full license information.
//  

namespace NickAc.LightPOS.Backend.Data
{
    public class BaseDbItem
    {
        public virtual long Id { get; set; }
        
        public virtual bool Deleted { get; set; }

        public virtual bool CanUpdate(out string error)
        {
            error = null;
            return true;
        }
    }
}