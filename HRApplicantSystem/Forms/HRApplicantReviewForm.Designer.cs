namespace HRApplicantSystem.Forms
{
    partial class HRApplicantReviewForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblNameValue = new System.Windows.Forms.Label();
            this.lblJob = new System.Windows.Forms.Label();
            this.lblJobValue = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblContactValue = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.rtbRemarks = new System.Windows.Forms.RichTextBox();
            this.btnStartReview = new System.Windows.Forms.Button();
            this.btnShortlist = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(110, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(309, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Applicant Review";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(15, 69);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(171, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Applicant Name:";
            // 
            // lblNameValue
            // 
            this.lblNameValue.AutoSize = true;
            this.lblNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameValue.Location = new System.Drawing.Point(187, 69);
            this.lblNameValue.Name = "lblNameValue";
            this.lblNameValue.Size = new System.Drawing.Size(19, 25);
            this.lblNameValue.TabIndex = 2;
            this.lblNameValue.Text = "-";
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJob.Location = new System.Drawing.Point(15, 107);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(175, 25);
            this.lblJob.TabIndex = 3;
            this.lblJob.Text = "Applied Position:";
            // 
            // lblJobValue
            // 
            this.lblJobValue.AutoSize = true;
            this.lblJobValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobValue.Location = new System.Drawing.Point(187, 107);
            this.lblJobValue.Name = "lblJobValue";
            this.lblJobValue.Size = new System.Drawing.Size(19, 25);
            this.lblJobValue.TabIndex = 4;
            this.lblJobValue.Text = "-";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(15, 145);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(159, 25);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Current Status:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusValue.Location = new System.Drawing.Point(187, 145);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(19, 25);
            this.lblStatusValue.TabIndex = 6;
            this.lblStatusValue.Text = "-";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(15, 181);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(94, 25);
            this.lblContact.TabIndex = 7;
            this.lblContact.Text = "Contact:";
            this.lblContact.Click += new System.EventHandler(this.lblContact_Click);
            // 
            // lblContactValue
            // 
            this.lblContactValue.AutoSize = true;
            this.lblContactValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactValue.Location = new System.Drawing.Point(187, 181);
            this.lblContactValue.Name = "lblContactValue";
            this.lblContactValue.Size = new System.Drawing.Size(19, 25);
            this.lblContactValue.TabIndex = 8;
            this.lblContactValue.Text = "-";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(15, 217);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(99, 25);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address:";
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.AutoSize = true;
            this.lblAddressValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressValue.Location = new System.Drawing.Point(187, 217);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Size = new System.Drawing.Size(19, 25);
            this.lblAddressValue.TabIndex = 10;
            this.lblAddressValue.Text = "-";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(15, 256);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(138, 25);
            this.lblRemarks.TabIndex = 11;
            this.lblRemarks.Text = "HR Remarks:";
            // 
            // rtbRemarks
            // 
            this.rtbRemarks.Location = new System.Drawing.Point(20, 294);
            this.rtbRemarks.Name = "rtbRemarks";
            this.rtbRemarks.Size = new System.Drawing.Size(500, 80);
            this.rtbRemarks.TabIndex = 12;
            this.rtbRemarks.Text = "";
            // 
            // btnStartReview
            // 
            this.btnStartReview.BackColor = System.Drawing.Color.SteelBlue;
            this.btnStartReview.ForeColor = System.Drawing.Color.White;
            this.btnStartReview.Location = new System.Drawing.Point(20, 396);
            this.btnStartReview.Name = "btnStartReview";
            this.btnStartReview.Size = new System.Drawing.Size(166, 38);
            this.btnStartReview.TabIndex = 13;
            this.btnStartReview.Text = "Start Review";
            this.btnStartReview.UseVisualStyleBackColor = false;
            this.btnStartReview.Click += new System.EventHandler(this.btnStartReview_Click);
            // 
            // btnShortlist
            // 
            this.btnShortlist.Location = new System.Drawing.Point(22, 443);
            this.btnShortlist.Name = "btnShortlist";
            this.btnShortlist.Size = new System.Drawing.Size(164, 30);
            this.btnShortlist.TabIndex = 14;
            this.btnShortlist.Text = "Shortlist Applicant";
            this.btnShortlist.UseVisualStyleBackColor = true;
            this.btnShortlist.Click += new System.EventHandler(this.btnShortlist_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Red;
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(22, 479);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(164, 35);
            this.btnReject.TabIndex = 15;
            this.btnReject.Text = "Reject Applicant";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(434, 485);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 29);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // HRApplicantReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 544);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnShortlist);
            this.Controls.Add(this.btnStartReview);
            this.Controls.Add(this.rtbRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblAddressValue);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblContactValue);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblStatusValue);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblJobValue);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblNameValue);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HRApplicantReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HR - Applicant Review";
            this.Load += new System.EventHandler(this.HRApplicantReviewForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNameValue;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblJobValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblContactValue;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.RichTextBox rtbRemarks;
        private System.Windows.Forms.Button btnStartReview;
        private System.Windows.Forms.Button btnShortlist;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnBack;
    }
}