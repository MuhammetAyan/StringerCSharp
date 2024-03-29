﻿using Models;
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
    public enum EditorMode
    {
        NewItem, EditItem
    }
    public partial class ItemEditor : Form
    {
        private EditorMode mode;

        private string OldPath;

        public string Path { get { return FileBusiness.Paths.Path(textBoxName.Text, Type); } }

        public ItemType Type { get; set; }

        public ItemEditor(EditorMode mode, ItemModel model = null)
        {
            InitializeComponent();
            switch (mode)
            {
                case EditorMode.NewItem:
                    Text = "Yeni Kayıt";
                    Save.Text = "Oluştur";
                    break;
                case EditorMode.EditItem:
                    Text = "Düzenle";
                    textBoxName.Text = model.Name;
                    this.Type = model.Type;
                    textBoxData.Text = model.Data;
                    checkBoxFavorite.Visible = false;
                    OldPath = model.Path;
                    Save.Text = "Değiştir";
                    break;
                default:
                    break;
            }
            this.mode = mode;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            var model = new ItemModel
            {
                Name = textBoxName.Text,
                Data = textBoxData.Text,
                Path = this.Path,
                Type = this.Type
            };
            switch (mode)
            {
                case EditorMode.NewItem:
                    Controllers.ItemController.NewItem(model);
                    break;
                case EditorMode.EditItem:
                    Controllers.ItemController.EditItem(OldPath, model);
                    break;
                default:
                    break;
            }
            Controllers.SwitchController.Refresh();
            Controllers.ItemController.Refresh();
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBoxFavorite_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFavorite.Checked)
                Type = ItemType.Favorite;
            else
                Type = ItemType.All;
        }
    }
}
