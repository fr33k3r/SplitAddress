namespace SplitAddresses
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TestStagingDBButton = new System.Windows.Forms.Button();
            this.TestLiveDBButton = new System.Windows.Forms.Button();
            this.FetchDataButton = new System.Windows.Forms.Button();
            this.AddressDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SplitAddressDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AddressDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitAddressDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TestStagingDBButton
            // 
            this.TestStagingDBButton.Location = new System.Drawing.Point(1234, 695);
            this.TestStagingDBButton.Name = "TestStagingDBButton";
            this.TestStagingDBButton.Size = new System.Drawing.Size(193, 33);
            this.TestStagingDBButton.TabIndex = 0;
            this.TestStagingDBButton.Text = "Test Staging DB Connection";
            this.TestStagingDBButton.UseVisualStyleBackColor = true;
            this.TestStagingDBButton.Click += new System.EventHandler(this.TestStagingDBButton_Click);
            // 
            // TestLiveDBButton
            // 
            this.TestLiveDBButton.Location = new System.Drawing.Point(1234, 734);
            this.TestLiveDBButton.Name = "TestLiveDBButton";
            this.TestLiveDBButton.Size = new System.Drawing.Size(193, 33);
            this.TestLiveDBButton.TabIndex = 1;
            this.TestLiveDBButton.Text = "Test Live DB Connection";
            this.TestLiveDBButton.UseVisualStyleBackColor = true;
            this.TestLiveDBButton.Click += new System.EventHandler(this.TestLiveDBButton_Click);
            // 
            // FetchDataButton
            // 
            this.FetchDataButton.Location = new System.Drawing.Point(12, 12);
            this.FetchDataButton.Name = "FetchDataButton";
            this.FetchDataButton.Size = new System.Drawing.Size(166, 48);
            this.FetchDataButton.TabIndex = 2;
            this.FetchDataButton.Text = "Read Address";
            this.FetchDataButton.UseVisualStyleBackColor = true;
            this.FetchDataButton.Click += new System.EventHandler(this.FetchDataButton_Click);
            // 
            // AddressDataGrid
            // 
            this.AddressDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.AddressDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddressDataGrid.Location = new System.Drawing.Point(12, 66);
            this.AddressDataGrid.Name = "AddressDataGrid";
            this.AddressDataGrid.ReadOnly = true;
            this.AddressDataGrid.Size = new System.Drawing.Size(1415, 291);
            this.AddressDataGrid.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(676, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Existing Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(676, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Split Fields Address";
            // 
            // SplitAddressDataGrid
            // 
            this.SplitAddressDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SplitAddressDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SplitAddressDataGrid.Location = new System.Drawing.Point(12, 387);
            this.SplitAddressDataGrid.Name = "SplitAddressDataGrid";
            this.SplitAddressDataGrid.Size = new System.Drawing.Size(1415, 267);
            this.SplitAddressDataGrid.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 779);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SplitAddressDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddressDataGrid);
            this.Controls.Add(this.FetchDataButton);
            this.Controls.Add(this.TestLiveDBButton);
            this.Controls.Add(this.TestStagingDBButton);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.AddressDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitAddressDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestStagingDBButton;
        private System.Windows.Forms.Button TestLiveDBButton;
        private System.Windows.Forms.Button FetchDataButton;
        private System.Windows.Forms.DataGridView AddressDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView SplitAddressDataGrid;
    }
}

