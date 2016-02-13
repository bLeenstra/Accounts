using System;
using System.Windows.Forms;
using CashFlowManager.Forms.Summary;

namespace CashFlowManager.Forms {
    public partial class MainScreen : Form {
        public MainScreen() {
            InitializeComponent();
        }

        private void btnViewNetWorth_Click(object sender, EventArgs e) {
            Summary.NetWorth netWorth = new NetWorth();
            netWorth.ShowDialog();
        }
    }
}
