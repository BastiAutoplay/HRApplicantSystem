namespace HRApplicantSystem.Forms
{
    partial class ApplicationStatusForm
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
            this.lblJob = new System.Windows.Forms.Label();
            this.lblJobValue = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblCurrentValue = new System.Windows.Forms.Label();
            this.lblInterview = new System.Windows.Forms.Label();
            this.lblInterviewValue = new System.Windows.Forms.Label();
            this.lvTimeline = new System.Windows.Forms.ListView();
            this.btnBack = new System.Windows.Forms.Button();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTimeline = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(49, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(478, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Application Status Timeline";
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJob.Location = new System.Drawing.Point(17, 60);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(96, 25);
            this.lblJob.TabIndex = 1;
            this.lblJob.Text = "Position:";
            // 
            // lblJobValue
            // 
            this.lblJobValue.AutoSize = true;
            this.lblJobValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobValue.Location = new System.Drawing.Point(232, 60);
            this.lblJobValue.Name = "lblJobValue";
            this.lblJobValue.Size = new System.Drawing.Size(19, 25);
            this.lblJobValue.TabIndex = 2;
            this.lblJobValue.Text = "-";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.Location = new System.Drawing.Point(17, 85);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(159, 25);
            this.lblCurrent.TabIndex = 3;
            this.lblCurrent.Text = "Current Status:";
            // 
            // lblCurrentValue
            // 
            this.lblCurrentValue.AutoSize = true;
            this.lblCurrentValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentValue.Location = new System.Drawing.Point(232, 85);
            this.lblCurrentValue.Name = "lblCurrentValue";
            this.lblCurrentValue.Size = new System.Drawing.Size(20, 25);
            this.lblCurrentValue.TabIndex = 4;
            this.lblCurrentValue.Text = "-";
            // 
            // lblInterview
            // 
            this.lblInterview.AutoSize = true;
            this.lblInterview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterview.Location = new System.Drawing.Point(17, 114);
            this.lblInterview.Name = "lblInterview";
            this.lblInterview.Size = new System.Drawing.Size(202, 25);
            this.lblInterview.TabIndex = 5;
            this.lblInterview.Text = "Interview Schedule:";
            // 
            // lblInterviewValue
            // 
            this.lblInterviewValue.AutoSize = true;
            this.lblInterviewValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterviewValue.ForeColor = System.Drawing.Color.Gray;
            this.lblInterviewValue.Location = new System.Drawing.Point(232, 114);
            this.lblInterviewValue.Name = "lblInterviewValue";
            this.lblInterviewValue.Size = new System.Drawing.Size(213, 25);
            this.lblInterviewValue.TabIndex = 6;
            this.lblInterviewValue.Text = "No interview scheduled";
            // 
            // lvTimeline
            // 
            this.lvTimeline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Stau,
            this.columnHeader3});
            this.lvTimeline.FullRowSelect = true;
            this.lvTimeline.GridLines = true;
            this.lvTimeline.HideSelection = false;
            this.lvTimeline.Location = new System.Drawing.Point(22, 176);
            this.lvTimeline.Name = "lvTimeline";
            this.lvTimeline.Size = new System.Drawing.Size(540, 250);
            this.lvTimeline.TabIndex = 8;
            this.lvTimeline.UseCompatibleStateImageBehavior = false;
            this.lvTimeline.View = System.Windows.Forms.View.Details;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(459, 444);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(83, 28);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 130;
            // 
            // Stau
            // 
            this.Stau.Text = "Status";
            this.Stau.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Remarks";
            this.columnHeader3.Width = 270;
            // 
            // lblTimeline
            // 
            this.lblTimeline.AutoSize = true;
            this.lblTimeline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeline.Location = new System.Drawing.Point(17, 148);
            this.lblTimeline.Name = "lblTimeline";
            this.lblTimeline.Size = new System.Drawing.Size(101, 25);
            this.lblTimeline.TabIndex = 10;
            this.lblTimeline.Text = "Timeline:";
            // 
            // ApplicationStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 494);
            this.Controls.Add(this.lblTimeline);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lvTimeline);
            this.Controls.Add(this.lblInterviewValue);
            this.Controls.Add(this.lblInterview);
            this.Controls.Add(this.lblCurrentValue);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblJobValue);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ApplicationStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Status";
            this.Load += new System.EventHandler(this.ApplicationStatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblJobValue;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblCurrentValue;
        private System.Windows.Forms.Label lblInterview;
        private System.Windows.Forms.Label lblInterviewValue;
        private System.Windows.Forms.ListView lvTimeline;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Stau;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTimeline;
    }
}