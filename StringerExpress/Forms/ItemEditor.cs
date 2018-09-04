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

        public string Path { get; set; }

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
                    this.Path = model.Path.LocalPath;
                    textBoxData.Text = model.Data;
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
            var model = new Models.ItemModel
            {
                Name = textBoxName.Text,
                Data = textBoxData.Text,
            };
            switch (mode)
            {
                case EditorMode.NewItem:
                    Controllers.ItemController.NewItem(model);
                    break;
                case EditorMode.EditItem:
                    model.Path = new Uri(FileBusiness.ItemBusiness.Path(model.Name));
                    Controllers.ItemController.EditItem(model);
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
