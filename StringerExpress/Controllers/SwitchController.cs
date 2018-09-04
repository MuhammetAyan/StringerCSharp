using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringerExpress.Controllers
{
    public static class SwitchController
    {
        private static Form form;

        public static void Form(Forms.Switch form)
        {
            if (SwitchController.form == null) SwitchController.form = form;
            else form.Close();
        }

        public static void Refresh()
        {
            List<ItemModel> Items = new List<ItemModel>();

        }

        public static void Open()
        {
            if (form == null) form = new Forms.Switch();
            form.Show();
            Refresh();
        }

        public static void Exit()
        {
        }
    }
}
