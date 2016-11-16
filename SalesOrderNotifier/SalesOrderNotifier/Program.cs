using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesOrderNotifier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Data.loadSalespersonSupervisorList() && Data.loadSalespersonEmailList())
                Application.Run(new MainForm());
            else
                Application.Run(new ExitForm(Data.userMessages));

        }
    }
}
