using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StringerExpress.Controllers
{
    public static class AppController
    {
        public static string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string VersionMajor
        {
            get
            {
                return Version.Split('.')[0] + "." + Version.Split('.')[1];
            }
        }
    }
}
