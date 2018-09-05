using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Models;

namespace FileBusiness
{
    public static class Paths
    {
        public static readonly string CURRENTFOLDER = Directory.GetCurrentDirectory();
        public static readonly string DEFAULTFOLDER = CURRENTFOLDER + @"\Items";
        public static readonly string FAVORITESFOLDER = CURRENTFOLDER + @"\Favorites";

        public static string Path(string name, ItemType type)
        {
            switch (type)
            {
                case ItemType.All:
                    return DEFAULTFOLDER + @"\" + name;
                case ItemType.Favorite:
                    return FAVORITESFOLDER + @"\" + name;
                default:
                    return DEFAULTFOLDER + @"\" + name;
            }

        }
    }
}
