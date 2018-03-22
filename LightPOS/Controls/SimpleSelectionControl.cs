using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NickAc.LightPOS.Backend.Utils;
using Enum = System.Enum;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class SimpleSelectionControl : Control
    {
        private Enum _selectedEnumValue;

        public class EnumEventArgs : EventArgs
        {
            public EnumEventArgs(Enum newEnumItem)
            {
                NewEnumItem = newEnumItem;
            }

            public Enum NewEnumItem { get; set; }
        }

        /// <summary>
        /// Called to signal to subscribers that the selection has been changed
        /// </summary>
        public event EventHandler<EnumEventArgs> SelectionChanged;

        protected virtual void OnSelectionChanged(Enum newItem)
        {
            var eh = SelectionChanged;

            eh?.Invoke(this, new EnumEventArgs(newItem));
        }


        public Color BorderColor { get; set; } = Color.FromArgb(200, 200, 200);
        public Color SelectedItemBackColor { get; set; } = Color.FromArgb(200, 200, 200);
        public Type OptionEnum { get; set; }

        public Enum SelectedEnumValue
        {
            get => _selectedEnumValue;
            set
            {
                if (value != null && !Equals(value, _selectedEnumValue))
                    OnSelectionChanged(value);
                _selectedEnumValue = value; 

            }
        }

        public SimpleSelectionControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                ControlStyles.UserMouse, true);
        }

        private object GetEnumItemAtLocation(Point location)
        {
            if (OptionEnum == null || !OptionEnum.IsEnum) return null;

            var enumValues = OptionEnum.GetEnumValues();
            var cellSize = ContentRectangle.Width / enumValues.Length;

            for (var i = 0; i < enumValues.Length; i++)
            {
                var value = (Enum) enumValues.GetValue(i);
                var rect = new Rectangle(ContentRectangle.X  + cellSize * i, ContentRectangle.Y, cellSize,
                    ContentRectangle.Height + 1);
                if (i + 1 == enumValues.Length) rect.Width += ContentRectangle.Right - rect.Right + 1;
                if (rect.Contains(location))
                    return value;
            }

            return SelectedEnumValue;
        }

        public Rectangle ContentRectangle => Rectangle.Inflate(DisplayRectangle, -2, -3);

        protected override void OnMouseClick(MouseEventArgs e)
        {
            SelectedEnumValue = GetEnumItemAtLocation(e.Location) as Enum;
            Invalidate(ContentRectangle);
        }

        private Color ColorForBackground(Color c)
        {
            var bright = Math.Sqrt(
                c.R * c.R * .299 +
                c.G * c.G * .587 +
                c.B * c.B * .114);
            return bright > 139 ? Color.Black : Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var containerRect = ContentRectangle;
            using (var foreColorBrush = new SolidBrush(ForeColor))
            {
                using (var altForeColorBrush = new SolidBrush(ColorForBackground(BackColor)))
                {
                    using (var borderPen = new Pen(BorderColor))
                    {
                        e.Graphics.DrawRectangle(borderPen,
                            containerRect);
                        if (OptionEnum == null || !OptionEnum.IsEnum) return;
                        var enumValues = OptionEnum.GetEnumValues();
                        var cellSize = containerRect.Width / enumValues.Length;
                        using (var sr = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        })
                        {
                            for (var i = 0; i < enumValues.Length; i++)
                            {
                                var value = (Enum) enumValues.GetValue(i);
                                var rect = new Rectangle(containerRect.X  + cellSize * i, containerRect.Y, cellSize,
                                    containerRect.Height + 1);
                                if (i + 1 == enumValues.Length) rect.Width += ContentRectangle.Right - rect.Right + 1;
                                var isSelected = SelectedEnumValue != null &&
                                                 Convert.ToInt32(SelectedEnumValue) == Convert.ToInt32(value);
                                if (isSelected)
                                {
                                    using (var backBrush = new SolidBrush(SelectedItemBackColor))
                                    {
                                        e.Graphics.FillRectangle(backBrush, Rectangle.Inflate(rect, -1, -1));
                                    }
                                }

                                e.Graphics.DrawString(value.GetDescription(), Font,
                                    isSelected ? altForeColorBrush : foreColorBrush, rect, sr);
                            }

                            e.Graphics.DrawRectangle(borderPen, containerRect);
                        }
                    }
                }
            }
        }
    }
}