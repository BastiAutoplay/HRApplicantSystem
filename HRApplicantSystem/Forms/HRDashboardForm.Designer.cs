namespace HRApplicantSystem.Forms
{
    partial class HRDashboardForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblTotalApplicants = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblPendingValue = new System.Windows.Forms.Label();
            this.lblShortlisted = new System.Windows.Forms.Label();
            this.lblShortlistedValue = new System.Windows.Forms.Label();
            this.btnApplicantList = new System.Windows.Forms.Button();
            this.btnJobVacancies = new System.Windows.Forms.Button();
            this.btnInterviewEval = new System.Windows.Forms.Button();
            this.btnHiringDecision = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnScreening = new System.Windows.Forms.Button();
            this.btnInterviewSched = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(185, 40);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome!";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.Gray;
            this.lblRole.Location = new System.Drawing.Point(12, 49);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(57, 25);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role:";
            // 
            // lblTotalApplicants
            // 
            this.lblTotalApplicants.AutoSize = true;
            this.lblTotalApplicants.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalApplicants.Location = new System.Drawing.Point(56, 121);
            this.lblTotalApplicants.Name = "lblTotalApplicants";
            this.lblTotalApplicants.Size = new System.Drawing.Size(175, 25);
            this.lblTotalApplicants.TabIndex = 2;
            this.lblTotalApplicants.Text = "Total Applicants:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValue.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalValue.Location = new System.Drawing.Point(109, 146);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(31, 32);
            this.lblTotalValue.TabIndex = 3;
            this.lblTotalValue.Text = "0";
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(302, 121);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(173, 25);
            this.lblPending.TabIndex = 4;
            this.lblPending.Text = "Pending Review:";
            // 
            // lblPendingValue
            // 
            this.lblPendingValue.AutoSize = true;
            this.lblPendingValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingValue.ForeColor = System.Drawing.Color.Orange;
            this.lblPendingValue.Location = new System.Drawing.Point(371, 146);
            this.lblPendingValue.Name = "lblPendingValue";
            this.lblPendingValue.Size = new System.Drawing.Size(31, 32);
            this.lblPendingValue.TabIndex = 5;
            this.lblPendingValue.Text = "0";
            // 
            // lblShortlisted
            // 
            this.lblShortlisted.AutoSize = true;
            this.lblShortlisted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortlisted.Location = new System.Drawing.Point(592, 121);
            this.lblShortlisted.Name = "lblShortlisted";
            this.lblShortlisted.Size = new System.Drawing.Size(122, 25);
            this.lblShortlisted.TabIndex = 6;
            this.lblShortlisted.Text = "Shortlisted:";
            // 
            // lblShortlistedValue
            // 
            this.lblShortlistedValue.AutoSize = true;
            this.lblShortlistedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortlistedValue.ForeColor = System.Drawing.Color.Green;
            this.lblShortlistedValue.Location = new System.Drawing.Point(638, 146);
            this.lblShortlistedValue.Name = "lblShortlistedValue";
            this.lblShortlistedValue.Size = new System.Drawing.Size(31, 32);
            this.lblShortlistedValue.TabIndex = 7;
            this.lblShortlistedValue.Text = "0";
            // 
            // btnApplicantList
            // 
            this.btnApplicantList.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApplicantList.ForeColor = System.Drawing.Color.White;
            this.btnApplicantList.Location = new System.Drawing.Point(159, 229);
            this.btnApplicantList.Name = "btnApplicantList";
            this.btnApplicantList.Size = new System.Drawing.Size(169, 48);
            this.btnApplicantList.TabIndex = 8;
            this.btnApplicantList.Text = "View Applicants";
            this.btnApplicantList.UseVisualStyleBackColor = false;
            this.btnApplicantList.Click += new System.EventHandler(this.btnApplicantList_Click);
            // 
            // btnJobVacancies
            // 
            this.btnJobVacancies.BackColor = System.Drawing.Color.SteelBlue;
            this.btnJobVacancies.ForeColor = System.Drawing.Color.White;
            this.btnJobVacancies.Location = new System.Drawing.Point(442, 229);
            this.btnJobVacancies.Name = "btnJobVacancies";
            this.btnJobVacancies.Size = new System.Drawing.Size(169, 48);
            this.btnJobVacancies.TabIndex = 9;
            this.btnJobVacancies.Text = "Job Vacancies";
            this.btnJobVacancies.UseVisualStyleBackColor = false;
            this.btnJobVacancies.Click += new System.EventHandler(this.btnJobVacancies_Click);
            // 
            // btnInterviewEval
            // 
            this.btnInterviewEval.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInterviewEval.ForeColor = System.Drawing.Color.White;
            this.btnInterviewEval.Location = new System.Drawing.Point(159, 382);
            this.btnInterviewEval.Name = "btnInterviewEval";
            this.btnInterviewEval.Size = new System.Drawing.Size(169, 48);
            this.btnInterviewEval.TabIndex = 10;
            this.btnInterviewEval.Text = "Interview Evaluation";
            this.btnInterviewEval.UseVisualStyleBackColor = false;
            this.btnInterviewEval.Click += new System.EventHandler(this.btnInterviewEval_Click);
            // 
            // btnHiringDecision
            // 
            this.btnHiringDecision.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHiringDecision.ForeColor = System.Drawing.Color.White;
            this.btnHiringDecision.Location = new System.Drawing.Point(442, 382);
            this.btnHiringDecision.Name = "btnHiringDecision";
            this.btnHiringDecision.Size = new System.Drawing.Size(169, 48);
            this.btnHiringDecision.TabIndex = 11;
            this.btnHiringDecision.Text = "Hiring Decision";
            this.btnHiringDecision.UseVisualStyleBackColor = false;
            this.btnHiringDecision.Click += new System.EventHandler(this.btnHiringDecision_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(159, 460);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(169, 48);
            this.btnReports.TabIndex = 12;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(442, 460);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(169, 48);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnScreening
            // 
            this.btnScreening.BackColor = System.Drawing.Color.SteelBlue;
            this.btnScreening.ForeColor = System.Drawing.Color.White;
            this.btnScreening.Location = new System.Drawing.Point(159, 307);
            this.btnScreening.Name = "btnScreening";
            this.btnScreening.Size = new System.Drawing.Size(169, 48);
            this.btnScreening.TabIndex = 14;
            this.btnScreening.Text = "Screening";
            this.btnScreening.UseVisualStyleBackColor = false;
            this.btnScreening.Click += new System.EventHandler(this.btnScreening_Click);
            // 
            // btnInterviewSched
            // 
            this.btnInterviewSched.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInterviewSched.ForeColor = System.Drawing.Color.White;
            this.btnInterviewSched.Location = new System.Drawing.Point(442, 302);
            this.btnInterviewSched.Name = "btnInterviewSched";
            this.btnInterviewSched.Size = new System.Drawing.Size(169, 53);
            this.btnInterviewSched.TabIndex = 15;
            this.btnInterviewSched.Text = "Interview Scheduling";
            this.btnInterviewSched.UseVisualStyleBackColor = false;
            this.btnInterviewSched.Click += new System.EventHandler(this.btnInterviewSched_Click);
            // 
            // HRDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.btnInterviewSched);
            this.Controls.Add(this.btnScreening);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnHiringDecision);
            this.Controls.Add(this.btnInterviewEval);
            this.Controls.Add(this.btnJobVacancies);
            this.Controls.Add(this.btnApplicantList);
            this.Controls.Add(this.lblShortlistedValue);
            this.Controls.Add(this.lblShortlisted);
            this.Controls.Add(this.lblPendingValue);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.lblTotalApplicants);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "HRDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HR Dashboard";
            this.Load += new System.EventHandler(this.HRDashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblTotalApplicants;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblPendingValue;
        private System.Windows.Forms.Label lblShortlisted;
        private System.Windows.Forms.Label lblShortlistedValue;
        private System.Windows.Forms.Button btnApplicantList;
        private System.Windows.Forms.Button btnJobVacancies;
        private System.Windows.Forms.Button btnInterviewEval;
        private System.Windows.Forms.Button btnHiringDecision;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnScreening;
        private System.Windows.Forms.Button btnInterviewSched;
    }
}