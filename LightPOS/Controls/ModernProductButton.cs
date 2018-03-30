using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NickAc.LightPOS.Backend.Objects;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Objects;

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
                ColorScheme = ColorScheme.CreateSimpleColorScheme(value.Category.Color);
                ForeColor = ColorScheme.ForegroundColor;
                Refresh();
            }
        }
    }
}