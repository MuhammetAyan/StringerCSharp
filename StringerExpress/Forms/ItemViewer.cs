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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            silToolStripMenuItem.Enabled = (itemView.SelectedItems.Count != 0);
            bool isOnlyItem = (itemView.SelectedItems.Count == 1);
            düzenleToolStripMenuItem.Enabled = isOnlyItem;
            çalıştırToolStripMenuItem.Enabled = isOnlyItem;
            favorilereEkleToolStripMenuItem.Enabled = (isOnlyItem && itemView.SelectedItems[0].Group.Header == "Tümü");
            favorilerdenÇıkarToolStripMenuItem.Enabled = (isOnlyItem && itemView.SelectedItems[0].Group.Header == "Favoriler");
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemController.EditItem(itemView.SelectedItems[0].Text);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in itemView.SelectedItems)
            {
                FileBusiness.ItemBusiness.DeleteItemByName(item.Text);
            }
            RefreshList();
        }

        private void favorilereEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = new Models.ProItemModel
            {
                Name = itemView.SelectedItems[0].Text,
                Path = new Uri(FileBusiness.ItemBusiness.Path(itemView.SelectedItems[0].Text)),
            };
            FileBusiness.FavoriteBusiness.AddFavorite(model);
        }

        private void favorilerdenÇıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
