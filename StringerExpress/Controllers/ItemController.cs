using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringerExpress.Forms;
using System.Windows.Forms;
using Models;

namespace StringerExpress.Controllers
{
    public static class ItemController
    {
        public static ItemEditor newItem { get; set; }
        public static ItemViewer listItem { get; set; }

        public static void NewItem()
        {
            newItem = new ItemEditor(EditorMode.NewItem);
            newItem.ShowDialog();
        }

        public static void NewItem(ItemModel model)
        {
            try
            {
                FileBusiness.ItemBusiness.AddItem(model);
                System.Windows.Forms.MessageBox.Show("Yeni kayıt oluşturuldu.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "HATA", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public static void ListItem()
        {
            listItem = new ItemViewer();
            listItem.ShowDialog();
        }

        public static ListViewItem[] ListRefresh(string searchText)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (var item in FileBusiness.FavoriteBusiness.GetFavoriteItems())
            {
                if (item.Name.ToLower().Contains(searchText))
                {
                    var listItem = new ListViewItem
                    {
                        Text = item.Name,
                        Group = ItemController.listItem.itemView.Groups["Favoriler"],
                    };
                    items.Add(listItem);
                }
            }
            foreach (var item in FileBusiness.ItemBusiness.GetItems())
            {
                if (item.Name.ToLower().Contains(searchText))
                {
                    var listItem = new ListViewItem
                    {
                        Text = item.Name,
                        Group = ItemController.listItem.itemView.Groups["Tümü"],
                    };
                    items.Add(listItem);
                }
            }
            return items.ToArray();
        }

    }
}
