using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounts.Forms.Summary;

namespace Accounts.Forms {
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
