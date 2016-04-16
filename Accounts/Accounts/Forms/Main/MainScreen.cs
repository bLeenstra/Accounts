using System;
using System.Windows.Forms;
using CashFlowManager.Forms.Summary;

namespace CashFlowManager.Forms.Main
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            using (DatabaseConfig config = new DatabaseConfig())
            {
                config.ShowDialog();
                if (config.DialogResult != DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private void btnViewNetWorth_Click(object sender, EventArgs e)
        {
            NetWorth netWorth = new NetWorth();
            netWorth.ShowDialog();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}