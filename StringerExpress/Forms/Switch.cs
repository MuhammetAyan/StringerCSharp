using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StringerExpress.Controllers;

namespace StringerExpress.Forms
{
    public partial class Switch : Form
    {
        public Switch()
        {
            InitializeComponent();
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemController.ListItem();
        }

        private void Switch_Load(object sender, EventArgs e)
        {
            
        }
    }
}
