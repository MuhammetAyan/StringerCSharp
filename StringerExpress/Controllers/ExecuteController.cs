using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace StringerExpress.Controllers
{
    public static partial class ExecuteController
    {
        /// <summary>
        /// Statik sınıfta kurucu metot olmadığından bu değişken ile ilk kurulum olup
        /// olmadığı kontrol ediliyor.
        /// </summary>
        private static bool IsSetup = true;

        private static bool isWork { get; set; }

        public static bool IsWork { get { return isWork; } }

        private static Timer timer = new Timer { Interval = 150 };

        private static Forms.ExecuteForm displayForm;

        public static void Execute(ItemModel model)
        {
            if (IsWork) throw new Exception("Zaten çalışan bir kayıt var.");
            isWork = true;
            Model = new ExecuteModel();
            Model.Finish += Model_Finish;
            Data = model.Data;
            Motor();
            displayForm = new Forms.ExecuteForm();
            displayForm.Show();
            OldClipboard = "";
            Clipboard.Clear();
            if (IsSetup)
            {
                timer.Tick += Timer_Tick;
                IsSetup = false;
            }
            timer.Start();
        }

        private static bool IsFinish = false;

        private static void Model_Finish()
        {
            Clipboard.SetText(Model.GetData());
            displayForm.BackColor = System.Drawing.Color.Green;
            IsFinish = true;
        }

        private static string OldClipboard = "";

        private static void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                var copy = Clipboard.GetText();
                if (OldClipboard != copy)
                {
                    if (IsFinish)
                    {
                        OldClipboard = Clipboard.GetText();
                        IsFinish = false;
                        return;
                    }
                    displayForm.BackColor = System.Drawing.Color.Red;
                    OldClipboard = "";
                    Clipboard.Clear();
                    Model.AddValue(copy);
                }
            }
            catch
            {}
        }

        public static void Close()
        {
            IsFinish = false;
            displayForm.Close();
            displayForm = null;
            timer.Stop();
            Model = null;
            isWork = false;
        }

    }
}
