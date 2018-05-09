using NickAc.LightPOS.Backend.Currency;
using NickAc.LightPOS.Backend.Objects;

namespace NickAc.LightPOS.Backend.Utils
{
    public static class GlobalStorage
    {
        static GlobalStorage()
        {
            CurrencyManager = new CurrencyManager();
            CurrencyManager.LoadCurrencies();
        }

        public static CurrencyManager CurrencyManager { get; set; }

        public static User CurrentUser { get; set; }
    }
}