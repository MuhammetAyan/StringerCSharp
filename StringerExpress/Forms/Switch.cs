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

        private void switchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public bool CTRL, SHIFT, C;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!CTRL)
                CTRL = GetAsyncKeyState((int)Keys.LControlKey) == System.Int16.MinValue + 1;
            else
            {
                if (!SHIFT)
                {
                    SHIFT = GetAsyncKeyState((int)Keys.LShiftKey) == System.Int16.MinValue + 1;
                    CTRL = SHIFT;
                }
                else
                {
                    if (!C)
                    {
                        C = GetAsyncKeyState((int)Keys.C) == System.Int16.MinValue + 1;
                        SHIFT = C;
                        CTRL = SHIFT;
                    }
                    else
                    {
                        CTRL = false;
                        SHIFT = false;
                        C = false;
                        Visible = true;
                    }
                }
            }
        }
    }
}
