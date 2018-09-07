using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringerExpress.Forms
{
    public partial class ExecuteForm : Form
    {
        public ExecuteForm()
        {
            InitializeComponent();
        }
        private int totalValue = 0;
        public int TotalValue
        {
            get { return totalValue; }
            set
            {
                totalValue = value;
                valueCount = 0;
                labelDisplay.Text = "0/" + totalValue;
            }
        }
        private int valueCount = 0;

        public int ValueCount
        {
            get { return valueCount; }
            set
            {
                valueCount = value;
                labelDisplay.Text = valueCount + "/" + totalValue;
            }
        }


        private void ExecuteForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(60, 20);
            this.Left = Screen.PrimaryScreen.Bounds.Right - 100;
            this.Top = Screen.PrimaryScreen.Bounds.Bottom - 100;
        }

        private void labelDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Controllers.ExecuteController.Close();
        }
    }
}
