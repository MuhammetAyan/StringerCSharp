using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Models;

namespace FileBusiness
{
    public static class ItemBusiness
    {
        public static readonly string FOLDER = Directory.GetCurrentDirectory() + @"\Items";

        public static string Path(string name)
        {
            return FOLDER + @"\" + name;
        }

        public static void Create()
        {
            if (!Directory.Exists(FOLDER))
                Directory.CreateDirectory(FOLDER);
        }

        public static List<ProItemModel> GetItems()
        {
            Create();
            List<ProItemModel> items = new List<ProItemModel>();
            foreach (var itemPath in Directory.GetFiles(FOLDER))
            {
                ProItemModel item = new ProItemModel
                {
                    Path = new Uri(itemPath),
                    Name = itemPath.Split('\\').Last()
                };
                items.Add(item);
            }
            return items;
        }

        public static ItemModel GetItemByName(string name)
        {
            Create();
            ItemModel model = new ItemModel();
            string data = File.ReadAllText(Path(name), Encoding.UTF8);
            model.Name = name;
            model.Path = new Uri(Path(name));
            model.Data = File.ReadAllText(Path(name), Encoding.UTF8);
            return model;
        }

        public static void DeleteItemByName(string name)
        {
            File.Delete(Path(name));
        }

        public static void AddItem(ItemModel model)
        {
            Create();
            if (model.Path == null)
                model.Path = new Uri(Path(model.Name));
            if(File.Exists(model.Path.LocalPath))
            {
                throw new Exception("Aynı isimde başka bir kayıt var!");
            }
            File.WriteAllText(model.Path.LocalPath, model.Data, Encoding.UTF8);
        }
    }
}
