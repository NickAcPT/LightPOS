namespace NickAc.LightPOS.Backend.Objects
{
    public class StoredSetting
    {
        public virtual string Id { get; set; }
        public virtual byte[] Data { get; set; }
    }
}