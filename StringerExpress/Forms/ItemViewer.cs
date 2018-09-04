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
    public partial class ItemViewer : Form
    {
        public ItemViewer()
        {
            InitializeComponent();
        }

        private void ItemViewer_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
        {
            itemView.Items.Clear();
            itemView.Items.AddRange(ItemController.ListRefresh(searchBox.Text));
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
