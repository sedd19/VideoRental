namespace VideoRentalApp
{
    partial class VideoList
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
            this.rbDVD = new System.Windows.Forms.RadioButton();
            this.rbVCD = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPric = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblcon = new System.Windows.Forms.Label();
            this.dgvVideo = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRatings = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.cmbRent = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // rbDVD
            // 
            this.rbDVD.AutoSize = true;
            this.rbDVD.Location = new System.Drawing.Point(63, 22);
            this.rbDVD.Name = "rbDVD";
            this.rbDVD.Size = new System.Drawing.Size(48, 19);
            this.rbDVD.TabIndex = 16;
            this.rbDVD.TabStop = true;
            this.rbDVD.Text = "DVD";
            this.rbDVD.UseVisualStyleBackColor = true;
            this.rbDVD.Click += new System.EventHandler(this.rbDVD_Click);
            // 
            // rbVCD
            // 
            this.rbVCD.AutoSize = true;
            this.rbVCD.Location = new System.Drawing.Point(6, 22);
            this.rbVCD.Name = "rbVCD";
            this.rbVCD.Size = new System.Drawing.Size(48, 19);
            this.rbVCD.TabIndex = 15;
            this.rbVCD.TabStop = true;
            this.rbVCD.Text = "VCD";
            this.rbVCD.UseVisualStyleBackColor = true;
            this.rbVCD.Click += new System.EventHandler(this.rbVCD_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(990, 425);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(115, 23);
            this.btnReset.TabIndex = 41;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 40;
            this.label9.Tag = "";
            this.label9.Text = "Search Video";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDVD);
            this.groupBox1.Controls.Add(this.rbVCD);
            this.groupBox1.Location = new System.Drawing.Point(994, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 53);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Category";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(93, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(240, 23);
            this.txtSearch.TabIndex = 39;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(789, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 35;
            this.label6.Tag = "";
            this.label6.Text = "Rent Price";
            // 
            // txtPric
            // 
            this.txtPric.Enabled = false;
            this.txtPric.Location = new System.Drawing.Point(789, 227);
            this.txtPric.Name = "txtPric";
            this.txtPric.Size = new System.Drawing.Size(183, 23);
            this.txtPric.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(789, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 33;
            this.label5.Tag = "";
            this.label5.Text = "Ratings";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblID.Location = new System.Drawing.Point(861, 89);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(40, 15);
            this.lblID.TabIndex = 31;
            this.lblID.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(789, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "VID CODE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(789, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 29;
            this.label2.Tag = "";
            this.label2.Text = "Movie Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(789, 139);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(183, 23);
            this.txtTitle.TabIndex = 28;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(869, 425);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(990, 396);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 23);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(869, 396);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 23);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblcon
            // 
            this.lblcon.AutoSize = true;
            this.lblcon.Location = new System.Drawing.Point(1106, 508);
            this.lblcon.Name = "lblcon";
            this.lblcon.Size = new System.Drawing.Size(50, 15);
            this.lblcon.TabIndex = 24;
            this.lblcon.Text = " lblconn";
            // 
            // dgvVideo
            // 
            this.dgvVideo.AllowUserToAddRows = false;
            this.dgvVideo.AllowUserToDeleteRows = false;
            this.dgvVideo.AllowUserToResizeColumns = false;
            this.dgvVideo.AllowUserToResizeRows = false;
            this.dgvVideo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVideo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvVideo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvVideo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideo.Location = new System.Drawing.Point(12, 89);
            this.dgvVideo.MultiSelect = false;
            this.dgvVideo.Name = "dgvVideo";
            this.dgvVideo.RowTemplate.Height = 25;
            this.dgvVideo.RowTemplate.ReadOnly = true;
            this.dgvVideo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVideo.Size = new System.Drawing.Size(771, 431);
            this.dgvVideo.TabIndex = 21;
            this.dgvVideo.SelectionChanged += new System.EventHandler(this.dgvVideo_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 42;
            this.label4.Text = "⁯MOVIE INFO";
            // 
            // cmbRatings
            // 
            this.cmbRatings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRatings.FormattingEnabled = true;
            this.cmbRatings.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbRatings.Location = new System.Drawing.Point(789, 183);
            this.cmbRatings.Name = "cmbRatings";
            this.cmbRatings.Size = new System.Drawing.Size(183, 23);
            this.cmbRatings.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(994, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 15);
            this.label8.TabIndex = 45;
            this.label8.Tag = "";
            this.label8.Text = "Stock";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(994, 227);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(183, 23);
            this.txtStock.TabIndex = 44;
            // 
            // cmbRent
            // 
            this.cmbRent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRent.FormattingEnabled = true;
            this.cmbRent.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbRent.Location = new System.Drawing.Point(789, 280);
            this.cmbRent.Name = "cmbRent";
            this.cmbRent.Size = new System.Drawing.Size(183, 23);
            this.cmbRent.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(789, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 46;
            this.label7.Tag = "";
            this.label7.Text = "Rent limit (days)";
            // 
            // VideoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 532);
            this.Controls.Add(this.cmbRent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.cmbRatings);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblcon);
            this.Controls.Add(this.dgvVideo);
            this.Name = "VideoList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoList";
            this.Load += new System.EventHandler(this.VideoList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton rbDVD;
        private RadioButton rbVCD;
        private Button btnReset;
        private Label label9;
        private GroupBox groupBox1;
        private TextBox txtSearch;
        private Label label6;
        private TextBox txtPric;
        private Label label5;
        private Label lblID;
        private Label label3;
        private Label label2;
        private TextBox txtTitle;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblcon;
        private DataGridView dgvVideo;
        private Label label4;
        private ComboBox cmbRatings;
        private Label label8;
        private TextBox txtStock;
        private ComboBox cmbRent;
        private Label label7;
    }
}