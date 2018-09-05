using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileBusiness;

namespace StringerExpress.Controllers
{
    public static class SwitchController
    {
        private static Forms.Switch form;

        public static void Form(Forms.Switch form)
        {
            if (SwitchController.form == null) SwitchController.form = form;
            else form.Close();
        }

        public static void Refresh()
        {
            var items = ItemBusiness.GetItems(ItemType.Favorite);
            var parent = form.ListPanel.Controls;
            parent.Clear();
            foreach (var item in items)
            {
                var control = new Forms.ItemButton();
                control.Text = item.Name;
                control.Click += Control_Click;
                parent.Add(control);
            }
            var addControl = new Forms.ItemButton(true);
            parent.Add(addControl);
        }

        private static void Control_Click(object sender, EventArgs e)
        {
            var model = ItemBusiness.GetItemByName(((Control)sender).Text, ItemType.Favorite);
            ExecuteController.Execute(model);
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
