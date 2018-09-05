using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Windows.Forms;

namespace StringerExpress.Controllers
{
    public static class ConvaterController
    {

        public static ProItemModel[] toModels(ListView.SelectedListViewItemCollection items)
        {
            List<ProItemModel> models = new List<ProItemModel>();
            foreach (ListViewItem item in items)
                models.Add(toModel(item));
            return models.ToArray();
        }

        public static ProItemModel[] toModels(ListViewItem[] items)
        {
            List<ProItemModel> models = new List<ProItemModel>();
            foreach (var item in items)
                models.Add(toModel(item));
            return models.ToArray();
        }

        public static ProItemModel toModel(ListViewItem item)
        {
            ProItemModel model = new ProItemModel
            {
                Name = item.Text,
                Path = FileBusiness.Paths.Path(item.Text, toItemType(item.SubItems[1].Text)),
            };
            model.Type = toItemType(item.SubItems[1].Text);
            return model;
        }

        public static ListViewItem tolistViewItem(ProItemModel model)
        {
            ListViewItem item = new ListViewItem();
            item.Text = model.Name;
            var subItem = new ListViewItem.ListViewSubItem { Text = fromItemType(model.Type) };
            item.SubItems.Add(subItem);
            return item;
        }

        public static ListViewItem[] tolistViewItems(ProItemModel[] models)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (var model in models)
                items.Add(tolistViewItem(model));
            return items.ToArray();
        }

        public static string fromItemType(ItemType type)
        {
            switch (type)
            {
                case ItemType.All:
                    return "";
                case ItemType.Favorite:
                    return "Favori";
                default:
                    return "";
            }
        }

        public static ItemType toItemType(string typeName)
        {
            switch (typeName)
            {
                case "": return ItemType.All;
                case "Favori": return ItemType.Favorite;
                default: return ItemType.All;
            }
        }
    }
}
