using System;
using System.Windows.Forms;
using PG_Administrator;

namespace postgres_database_restore_tool
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PgAdmin());
        }
    }
}
