using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CashFlowManager.Data;

namespace CashFlowManager.Forms.Main
{
    public partial class DatabaseConfig : Form
    {
        private int _attempts;

        public DatabaseConfig()
        {
            InitializeComponent();

            LoadTestingValues();
        }

        private void LoadTestingValues()
        {
            txtAddress.Text = "localhost";
            txtPort.Value = 3306;
            txtUsername.Text = "root";

            txtPassword.Focus();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Database.SetDatabaseConnection(txtAddress.Text, Convert.ToUInt32(txtPort.Value), txtUsername.Text,
                txtPassword.Text))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Could not connect to database");
                _attempts++;
                if (_attempts >= 3)
                {
                    DialogResult = DialogResult.No;
                }
            }
        }
    }
}