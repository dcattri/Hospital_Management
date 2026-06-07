using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
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
            using (var ctx = new AppContext())
            {
                Application.Run(ctx);
            }
        }
        private class AppContext : ApplicationContext
        {
            public AppContext()
            {
                var login = new frmLogin();
                login.FormClosed += (s, e) => { ExitThread(); };
                login.Show();
            }
            protected override void ExitThreadCore()
            {
                try { AuditTrail.Shutdown(); } catch { }
                base.ExitThreadCore();
            }
        }
    }
}
