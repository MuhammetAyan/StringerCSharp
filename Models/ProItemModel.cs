using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProItemModel
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsFavorite { get { return Type == ItemType.Favorite; } }

        public ItemType Type { get; set; }
    }
}
