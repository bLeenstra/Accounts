using System;
using System.Windows.Forms;
using CashFlowManager.Forms.Summary;

namespace CashFlowManager {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NetWorth());
        }
    }
}
