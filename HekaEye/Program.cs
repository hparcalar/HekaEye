using HekaEye.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HekaEye
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

            var configuration = new Configuration();
            configuration.TargetDatabase = new DbConnectionInfo("EyeContext");

            var migrator = new DbMigrator(configuration);
            migrator.Update();

            Application.Run(new frmStudioHome());
        }
    }
}
