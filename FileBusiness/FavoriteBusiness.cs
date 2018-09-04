using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Models;

namespace FileBusiness
{
    public static class FavoriteBusiness
    {
        public static readonly string PATH = System.IO.Directory.GetCurrentDirectory() + @"\Favorites";

        public static void Create()
        {
            if (!File.Exists(PATH))
                File.WriteAllText(PATH, "", Encoding.UTF8);
        }

        public static List<FavoriteItemModel> GetFavoriteItems()
        {
            Create();
            List<FavoriteItemModel> favoriteItems = new List<FavoriteItemModel>();
            string[] lines = File.ReadAllLines(PATH, Encoding.UTF8);
            int i = 0;
            foreach (var line in lines)
            {
                FavoriteItemModel favorite = new FavoriteItemModel
                {
                    Name = line.Trim(),
                    Index = i++
                };
                favoriteItems.Add(favorite);
            }
            return favoriteItems;
        }

        public static void AddFavorite(ProItemModel item)
        {
            Create();
            List<string> line = new List<string>();
            line.Add(item.Name);
            File.AppendAllLines(PATH, line, Encoding.UTF8);
        }
    }
}
