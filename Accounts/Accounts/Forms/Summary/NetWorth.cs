using System.Windows.Forms;

namespace CashFlowManager.Forms.Summary {
    public partial class NetWorth : Form {
        public NetWorth() {
            InitializeComponent();
            RefreshData();
        }

        private void btnExit_Click(object sender, System.EventArgs e) {
            this.Close();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e) {
            RefreshData();
        }

        private void RefreshData() {
            //get total assets
            //get current liabilites
            //work out net worth
        }
    }
}
