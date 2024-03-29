﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            this.Text = this.Text.Replace("{version}", AppController.VersionMajor);
            ItemController.Refresh(searchBox.Text);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            ItemController.Refresh(searchBox.Text);
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
            ItemController.Refresh(searchBox.Text);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemController.DeleteItems(ConvaterController.toModels(itemView.SelectedItems));
            ItemController.Refresh(searchBox.Text);
        }

        private void favorilereEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = ConvaterController.toModel(itemView.SelectedItems[0]);
            ItemController.AddFavorite(model);
            ItemController.Refresh(searchBox.Text);
        }

        private void favorilerdenÇıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = ConvaterController.toModel(itemView.SelectedItems[0]);
            ItemController.RemoveFromFavorite(model);
            ItemController.Refresh(searchBox.Text);
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
