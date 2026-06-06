namespace HRApplicantSystem.Forms
{
    partial class HiringDecisionForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvApplicants = new System.Windows.Forms.ListView();
            this.lblApplicant = new System.Windows.Forms.Label();
            this.lblApplicantValue = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblPositionValue = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.rtbRemarks = new System.Windows.Forms.RichTextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnHold = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(368, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Final Hiring Decision";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(16, 63);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(151, 22);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search Applicant:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(173, 63);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(447, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 35);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvApplicants
            // 
            this.lvApplicants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvApplicants.FullRowSelect = true;
            this.lvApplicants.GridLines = true;
            this.lvApplicants.HideSelection = false;
            this.lvApplicants.Location = new System.Drawing.Point(20, 99);
            this.lvApplicants.Name = "lvApplicants";
            this.lvApplicants.Size = new System.Drawing.Size(540, 200);
            this.lvApplicants.TabIndex = 5;
            this.lvApplicants.UseCompatibleStateImageBehavior = false;
            this.lvApplicants.View = System.Windows.Forms.View.Details;
            this.lvApplicants.SelectedIndexChanged += new System.EventHandler(this.lvApplicants_SelectedIndexChanged);
            // 
            // lblApplicant
            // 
            this.lblApplicant.AutoSize = true;
            this.lblApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicant.Location = new System.Drawing.Point(24, 302);
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.Size = new System.Drawing.Size(109, 25);
            this.lblApplicant.TabIndex = 6;
            this.lblApplicant.Text = "Applicant:";
            this.lblApplicant.Click += new System.EventHandler(this.lblApplicant_Click);
            // 
            // lblApplicantValue
            // 
            this.lblApplicantValue.AutoSize = true;
            this.lblApplicantValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicantValue.Location = new System.Drawing.Point(148, 302);
            this.lblApplicantValue.Name = "lblApplicantValue";
            this.lblApplicantValue.Size = new System.Drawing.Size(19, 25);
            this.lblApplicantValue.TabIndex = 7;
            this.lblApplicantValue.Text = "-";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(24, 327);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(96, 25);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "Position:";
            this.lblPosition.Click += new System.EventHandler(this.lblPosition_Click);
            // 
            // lblPositionValue
            // 
            this.lblPositionValue.AutoSize = true;
            this.lblPositionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositionValue.Location = new System.Drawing.Point(148, 327);
            this.lblPositionValue.Name = "lblPositionValue";
            this.lblPositionValue.Size = new System.Drawing.Size(19, 25);
            this.lblPositionValue.TabIndex = 9;
            this.lblPositionValue.Text = "-";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(24, 352);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(103, 25);
            this.lblRemarks.TabIndex = 12;
            this.lblRemarks.Text = "Remarks:";
            // 
            // rtbRemarks
            // 
            this.rtbRemarks.Location = new System.Drawing.Point(29, 380);
            this.rtbRemarks.Name = "rtbRemarks";
            this.rtbRemarks.Size = new System.Drawing.Size(500, 80);
            this.rtbRemarks.TabIndex = 13;
            this.rtbRemarks.Text = "";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(447, 539);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(77, 35);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Green;
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(41, 475);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(149, 43);
            this.btnAccept.TabIndex = 16;
            this.btnAccept.Text = "Accept Applicant";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnHold
            // 
            this.btnHold.BackColor = System.Drawing.Color.Orange;
            this.btnHold.ForeColor = System.Drawing.Color.White;
            this.btnHold.Location = new System.Drawing.Point(388, 475);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(149, 43);
            this.btnHold.TabIndex = 17;
            this.btnHold.Text = "Put on Hold";
            this.btnHold.UseVisualStyleBackColor = false;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Red;
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(217, 475);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(149, 43);
            this.btnReject.TabIndex = 18;
            this.btnReject.Text = "Reject Applicant";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "App ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Applicant Name";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Position";
            this.columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 110;
            // 
            // HiringDecisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 586);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnHold);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.rtbRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblPositionValue);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblApplicantValue);
            this.Controls.Add(this.lblApplicant);
            this.Controls.Add(this.lvApplicants);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HiringDecisionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hiring Decision";
            this.Load += new System.EventHandler(this.HiringDecisionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvApplicants;
        private System.Windows.Forms.Label lblApplicant;
        private System.Windows.Forms.Label lblApplicantValue;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblPositionValue;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.RichTextBox rtbRemarks;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}