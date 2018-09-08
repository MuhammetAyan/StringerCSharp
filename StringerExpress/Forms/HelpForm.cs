using StringerExpress.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringerExpress.Forms
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("{version}", AppController.VersionMajor);
            var fileNames = HelpData.ResourceManager.GetString("FileNames").Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
            listBoxSideBar.Items.Clear();
            listBoxSideBar.Items.AddRange(fileNames);
        }

        private void listBoxSideBar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string d0 = Directory.GetCurrentDirectory() + @"\bootstrap.min.css";
                webBrowser1.DocumentText = HelpData.ResourceManager.GetString(listBoxSideBar.SelectedItem.ToString()).Replace("<0>", d0);
            }
            catch
            {
                webBrowser1.DocumentText = "<h1>Bir hata oluştu.</h1>";
            }

        }
    }
}
