namespace VideoRentalApp
{
    partial class RentalView
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
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRent = new System.Windows.Forms.Button();
            this.lblcon = new System.Windows.Forms.Label();
            this.dgvVideolist = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideolist)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(4, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 65;
            this.label4.Text = "⁯MOVIE RENTAL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 63;
            this.label9.Tag = "";
            this.label9.Text = "Search Video";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, -37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 49;
            this.label1.Text = "label1";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(85, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(240, 23);
            this.txtSearch.TabIndex = 62;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRent
            // 
            this.btnRent.Location = new System.Drawing.Point(273, 515);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(115, 23);
            this.btnRent.TabIndex = 52;
            this.btnRent.Text = "Rent";
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // lblcon
            // 
            this.lblcon.AutoSize = true;
            this.lblcon.Location = new System.Drawing.Point(772, 526);
            this.lblcon.Name = "lblcon";
            this.lblcon.Size = new System.Drawing.Size(50, 15);
            this.lblcon.TabIndex = 50;
            this.lblcon.Text = " lblconn";
            // 
            // dgvVideolist
            // 
            this.dgvVideolist.AllowUserToAddRows = false;
            this.dgvVideolist.AllowUserToDeleteRows = false;
            this.dgvVideolist.AllowUserToResizeColumns = false;
            this.dgvVideolist.AllowUserToResizeRows = false;
            this.dgvVideolist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVideolist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvVideolist.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvVideolist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideolist.Location = new System.Drawing.Point(4, 71);
            this.dgvVideolist.MultiSelect = false;
            this.dgvVideolist.Name = "dgvVideolist";
            this.dgvVideolist.RowTemplate.Height = 25;
            this.dgvVideolist.RowTemplate.ReadOnly = true;
            this.dgvVideolist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVideolist.Size = new System.Drawing.Size(862, 431);
            this.dgvVideolist.TabIndex = 48;
            this.dgvVideolist.SelectionChanged += new System.EventHandler(this.dgvVideolist_SelectionChanged);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(394, 515);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(115, 23);
            this.btnReturn.TabIndex = 51;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblstatus.Location = new System.Drawing.Point(374, 42);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(158, 21);
            this.lblstatus.TabIndex = 66;
            this.lblstatus.Text = "Select movie to rent";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 515);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 67;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RentalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.lblcon);
            this.Controls.Add(this.dgvVideolist);
            this.Controls.Add(this.btnReturn);
            this.Name = "RentalView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentalView";
            this.Load += new System.EventHandler(this.RentalView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideolist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label4;
        private Label label9;
        private Label label1;
        private TextBox txtSearch;
        private Button btnRent;
        private Label lblcon;
        private DataGridView dgvVideolist;
        private Button btnReturn;
        private Label lblstatus;
        private Button button1;
    }
}