using StringerExpress.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringerExpress
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new Switch();
            Controllers.SwitchController.Form(main);
            Controllers.SwitchController.Refresh();
            Application.Run(main);
            
        }
    }
}
