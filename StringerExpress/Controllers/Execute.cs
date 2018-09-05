using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace StringerExpress.Controllers
{
    public static partial class ExecuteController
    {
        private static int i;

        /// <summary>
        /// Model.Data bilgisini içerir.
        /// </summary>
        private static string Data;

        private static ExecuteModel Model;

        private static string TEMP;

        private static void Motor()
        {
            TEMP = "";
            for (i = 0; i < Data.Length; i++)
            {
                if (Data[i] == '{')
                {
                    Model.AddWord(TEMP);
                    TEMP = "{";
                    i++;
                    Arguman();
                }
                else
                    TEMP += Data[i];
            }
            if (TEMP != "")
                Model.AddWord(TEMP);
        }

        private static void Arguman()
        {
            string temp = "";
            for (; i < Data.Length; i++)
            {
                if (char.IsDigit(Data[i]))
                    temp += Data[i];
                else if (Data[i] == '}')
                {
                    Model.AddWord("", Convert.ToInt32(temp));
                    TEMP = "";
                    return;
                }
                else
                {
                    temp += Data[i];
                    TEMP += temp;
                    i++;
                    return;
                }
            }
            if (temp != "")
                TEMP += temp;
        }

    }
}
