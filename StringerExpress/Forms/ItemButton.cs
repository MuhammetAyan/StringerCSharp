using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringerExpress.Forms
{
    public partial class ItemButton : Button
    {
        public ItemButton(bool addButton = false)
        {
            this.Size = new System.Drawing.Size(50, 50);
            this.FlatStyle = FlatStyle.Flat;
            if (addButton)
            {
                this.BackColor = System.Drawing.Color.LightGreen;
                this.Text = "+";
                this.Click += ItemButton_Click;
            }
            else
            {
                this.BackColor = System.Drawing.Color.LightCyan;
            }
        }

        private void ItemButton_Click(object sender, EventArgs e)
        {
            //Open Add Favorite Dialog
            throw new NotImplementedException();
        }
    }
}
