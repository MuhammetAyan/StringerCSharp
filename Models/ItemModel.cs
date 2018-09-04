using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemModel
    {
        public string Name { get; set; }

        public Uri Path { get; set; }

        public string Read()
        {
            return System.IO.File.ReadAllText(Path.LocalPath, Encoding.UTF8);
        }
    }
}
