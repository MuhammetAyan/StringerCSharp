using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringerExpress.Forms;
using System.Windows.Forms;
using Models;
using FileBusiness;

namespace StringerExpress.Controllers
{
    public static class ItemController
    {
        public static ItemEditor newItem { get; set; }
        public static ItemEditor editItem { get; set; }
        public static ItemViewer listItem { get; set; }

        public static void NewItem(bool isFavorite = false)
        {
            newItem = new ItemEditor(EditorMode.NewItem);
            newItem.checkBoxFavorite.Checked = isFavorite;
            newItem.ShowDialog();
        }

        public static void NewItem(ItemModel model)
        {
            try
            {
                ItemBusiness.AddItem(model);
                MessageBox.Show("Yeni kayıt oluşturuldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void EditItem(ProItemModel model)
        {
            ItemModel m = ItemBusiness.GetItemByName(model.Name, model.Type);
            editItem = new ItemEditor(EditorMode.EditItem, m);
            editItem.ShowDialog();
        }

        public static void EditItem(string OldPath, ItemModel model)
        {
            try
            {
                ItemBusiness.EditItem(OldPath, model);
                MessageBox.Show("Kayıt düzenlendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ListItem()
        {
            listItem = new ItemViewer();
            listItem.ShowDialog();
        }

        public static void Refresh(string searchText)
        {
            if (listItem == null) return;
            var FavoriteModels = ItemBusiness.GetItems(ItemType.Favorite).Where(x => x.Name.ToLower().Contains(searchText));
            var FavoriteItems = ConvaterController.tolistViewItems(FavoriteModels.ToArray());
            var AllModels = ItemBusiness.GetItems(ItemType.All).Where(x => x.Name.ToLower().Contains(searchText));
            var AllItems = ConvaterController.tolistViewItems(AllModels.ToArray());
            var data = FavoriteItems.Union(AllItems.ToList()).ToArray();
            listItem.itemView.Items.Clear();
            listItem.itemView.Items.AddRange(data);
        }

        public static void Refresh()
        {
            if(listItem != null)
            Refresh(listItem.searchBox.Text);
        }

        public static void DeleteItem(ProItemModel model)
        {
            ItemBusiness.DeleteItemByName(model.Name, model.Type);
        }

        public static void DeleteItems(ProItemModel[] models)
        {
            foreach (var model in models)
                DeleteItem(model);
        }

        public static void AddFavorite(ProItemModel model)
        {
            ItemBusiness.AddFavorite(model);
            SwitchController.Refresh();
        }

        public static void RemoveFromFavorite(ProItemModel model)
        {
            ItemBusiness.RemoveFromFavorite(model);
            SwitchController.Refresh();
        }
    }
}
