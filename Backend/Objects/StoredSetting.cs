using Newtonsoft.Json;

namespace NickAc.LightPOS.Backend.Objects
{
    public class StoredSetting
    {
        public virtual string Id { get; set; }
        
        public virtual string Data { get; set; }

        public virtual object Value { get; set; }
    }
}