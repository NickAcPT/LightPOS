//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Controls.DrawHandler
{
    public abstract class ListBoxDrawHandler : IDisposable
    {
        protected ListBoxDrawHandler(ListBox control)
        {
            Control = control;
            control.DrawMode = DrawMode.OwnerDrawVariable;
            control.MeasureItem += MeasureItemEventHandler;
            control.DrawItem += DrawItemEventHandler;
        }

        public ListBox Control { get; }

        public void Dispose()
        {
            Control.DrawMode = DrawMode.Normal;
            Control.MeasureItem -= MeasureItemEventHandler;
            Control.DrawItem -= DrawItemEventHandler;
        }

        private void MeasureItemEventHandler(object s, MeasureItemEventArgs e)
        {
            MeasureItem(e);
        }

        private void DrawItemEventHandler(object s, DrawItemEventArgs e)
        {
            DrawItem(e);
        }

        public abstract void DrawItem(DrawItemEventArgs e);
        public abstract void MeasureItem(MeasureItemEventArgs e);
    }
}