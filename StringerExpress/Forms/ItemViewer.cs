using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileBusiness;
using Models;
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
            favorilereEkleToolStripMenuItem.Enabled = (isOnlyItem && itemView.SelectedItems[0].SubItems[1].Text == ConvaterController.fromItemType(ItemType.All));
            favorilerdenÇıkarToolStripMenuItem.Enabled = (isOnlyItem && itemView.SelectedItems[0].SubItems[1].Text == ConvaterController.fromItemType(ItemType.Favorite));
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemController.EditItem(ConvaterController.toModel(itemView.SelectedItems[0]));
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemController.DeleteItems(ConvaterController.toModels(itemView.SelectedItems));
            RefreshList();
        }

        private void favorilereEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = ConvaterController.toModel(itemView.SelectedItems[0]);
            ItemController.AddFavorite(model);
            RefreshList();
        }

        private void favorilerdenÇıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = ConvaterController.toModel(itemView.SelectedItems[0]);
            ItemController.RemoveFromFavorite(model);
            RefreshList();
        }

        private void ItemViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ItemController.listItem = null;
        }

        private void çalıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = ConvaterController.toModel(itemView.SelectedItems[0]);
            ExecuteController.Execute(ItemBusiness.GetItemByName(model.Name, model.Type));
        }
    }
}
