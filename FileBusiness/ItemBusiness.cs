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

        public static void Create()
        {
            if (!Directory.Exists(Paths.DEFAULTFOLDER))
                Directory.CreateDirectory(Paths.DEFAULTFOLDER);
            if (!Directory.Exists(Paths.FAVORITESFOLDER))
                Directory.CreateDirectory(Paths.FAVORITESFOLDER);
        }

        public static List<ProItemModel> GetItems(ItemType type)
        {
            Create();
            List<ProItemModel> items = new List<ProItemModel>();
            var PATH = (type == ItemType.All) ? Paths.DEFAULTFOLDER : Paths.FAVORITESFOLDER;
            foreach (var itemPath in Directory.GetFiles(PATH))
            {
                ProItemModel item = new ProItemModel
                {
                    Path = itemPath,
                    Name = itemPath.Split('\\').Last(),
                    Type = type,
                };
                items.Add(item);
            }
            return items;
        }

        public static ItemModel GetItemByName(string name, ItemType type)
        {
            Create();
            ItemModel model = new ItemModel();
            string data = File.ReadAllText(Paths.Path(name, type), Encoding.UTF8);
            model.Name = name;
            model.Path = Paths.Path(name, type);
            model.Data = File.ReadAllText(Paths.Path(name, type), Encoding.UTF8);
            model.Type = type;
            return model;
        }

        public static void DeleteItemByName(string name, ItemType type)
        {
            File.Delete(Paths.Path(name, type));
        }

        public static void AddItem(ItemModel model)
        {
            Create();
            if (model.Path == null)
                model.Path = Paths.Path(model.Name, ItemType.All);
            if (File.Exists(model.Path))
            {
                throw new Exception("Aynı isimde başka bir kayıt var!");
            }
            File.WriteAllText(model.Path, model.Data, Encoding.UTF8);
        }

        public static void EditItem(string OldPath, ItemModel model)
        {
            Create();
            if (model.Path != OldPath && File.Exists(model.Path))
            {
                throw new Exception("Aynı isimde başka bir kayıt var!");
            }
            File.Delete(OldPath);
            File.WriteAllText(model.Path, model.Data, Encoding.UTF8);
        }

        public static void RemoveFromFavorite(ProItemModel model)
        {
            File.Move(model.Path, Paths.Path(model.Name, ItemType.All));
        }

        public static void AddFavorite(ProItemModel model)
        {
            File.Move(model.Path, Paths.Path(model.Name, ItemType.Favorite));
        }
    }
}
