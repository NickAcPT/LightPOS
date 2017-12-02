using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NickAc.LightPOS.Frontend.Controls
{
    public class TextBoxEx : TextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Back | Keys.Control)) {
                for (int i = this.SelectionStart - 1; i > 0; i--) {
                    string v = Text.Substring(i, 1);
                    switch (v) {    //set up any stopping points you want
                        case " ":
                        case ";":
                        case ",":
                        case "/":
                        case "\\":
                            Text = Text.Remove(i, SelectionStart - i);
                            Text = Text.Insert(i, v);
                            SelectionStart = i + 1;
                            return true;
                        case "\n":
                            Text = Text.Remove(i - 1, SelectionStart - i);
                            SelectionStart = i;
                            return true;
                    }
                }
                //in case you never hit a stopping point, the whole textbox goes blank
                Text = Text.Remove(0, SelectionStart);
                SelectionStart = 0;
                //Clear();
                return true;
            }
            else {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
