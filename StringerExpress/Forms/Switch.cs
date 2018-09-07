using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StringerExpress.Controllers;

namespace StringerExpress.Forms
{

    public partial class Switch : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern short GetAsyncKeyState(int Tus);

        public Switch()
        {
            InitializeComponent();
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemController.ListItem();
        }

        private void Switch_Load(object sender, EventArgs e)
        {

        }

        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemController.NewItem();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Stop();
        }

        public bool CTRL, SHIFT, C;

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void switchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 256; i++)
            {
                if (GetAsyncKeyState(i) == -32767)
                {
                    switch (i)
                    {
                        case 162:
                        case 17:
                            CTRL = true;
                            break;
                        case 16:
                        case 160:
                            if (CTRL)
                            {
                                SHIFT = true;
                            }
                            else
                                CTRL = false;
                            break;
                        case 67:
                            if (SHIFT)
                            {
                                //C = true;
                                CTRL = false;
                                SHIFT = false;
                                Visible = true;
                            }
                            else
                            {
                                SHIFT = false;
                                CTRL = false;
                            }
                            break;
                        default:
                            CTRL = false;
                            SHIFT = false;
                            C = false;
                            break;
                    }
                    break;
                }
            }
        }
    }
}
