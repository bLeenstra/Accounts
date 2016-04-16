namespace CashFlowManager.Forms.Main {
    partial class MainScreen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnViewNetWorth = new System.Windows.Forms.Button();
            this.btnAddAsset = new System.Windows.Forms.Button();
            this.btnConfigureAccounts = new System.Windows.Forms.Button();
            this.btnImportTransactions = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewNetWorth
            // 
            this.btnViewNetWorth.Location = new System.Drawing.Point(12, 12);
            this.btnViewNetWorth.Name = "btnViewNetWorth";
            this.btnViewNetWorth.Size = new System.Drawing.Size(292, 50);
            this.btnViewNetWorth.TabIndex = 0;
            this.btnViewNetWorth.Text = "View Net Worth";
            this.btnViewNetWorth.UseVisualStyleBackColor = true;
            this.btnViewNetWorth.Click += new System.EventHandler(this.btnViewNetWorth_Click);
            // 
            // btnAddAsset
            // 
            this.btnAddAsset.Location = new System.Drawing.Point(12, 124);
            this.btnAddAsset.Name = "btnAddAsset";
            this.btnAddAsset.Size = new System.Drawing.Size(292, 50);
            this.btnAddAsset.TabIndex = 1;
            this.btnAddAsset.Text = "Add Asset";
            this.btnAddAsset.UseVisualStyleBackColor = true;
            // 
            // btnConfigureAccounts
            // 
            this.btnConfigureAccounts.Location = new System.Drawing.Point(12, 68);
            this.btnConfigureAccounts.Name = "btnConfigureAccounts";
            this.btnConfigureAccounts.Size = new System.Drawing.Size(292, 50);
            this.btnConfigureAccounts.TabIndex = 2;
            this.btnConfigureAccounts.Text = "Configure Accounts";
            this.btnConfigureAccounts.UseVisualStyleBackColor = true;
            // 
            // btnImportTransactions
            // 
            this.btnImportTransactions.Location = new System.Drawing.Point(12, 180);
            this.btnImportTransactions.Name = "btnImportTransactions";
            this.btnImportTransactions.Size = new System.Drawing.Size(292, 50);
            this.btnImportTransactions.TabIndex = 3;
            this.btnImportTransactions.Text = "Import Transactions";
            this.btnImportTransactions.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(12, 236);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(292, 50);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 307);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnImportTransactions);
            this.Controls.Add(this.btnConfigureAccounts);
            this.Controls.Add(this.btnAddAsset);
            this.Controls.Add(this.btnViewNetWorth);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private global::System.Windows.Forms.Button btnViewNetWorth;
        private global::System.Windows.Forms.Button btnAddAsset;
        private global::System.Windows.Forms.Button btnConfigureAccounts;
        private global::System.Windows.Forms.Button btnImportTransactions;
        private System.Windows.Forms.Button btnQuit;
    }
}