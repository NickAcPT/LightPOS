using NickAc.LightPOS.Backend.Objects;
using NickAc.ModernUIDoneRight.Controls;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class ModernProductButton : ModernButton
    {
        private Product _product;

        public ModernProductButton(Product product)
        {
            Product = product;
        }

        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                ForeColor = ColorScheme.ForegroundColor;
                Refresh();
            }
        }
    }
}