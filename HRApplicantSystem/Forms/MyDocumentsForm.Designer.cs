namespace HRApplicantSystem.Forms
{
    partial class MyDocumentsForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lvDocuments = new System.Windows.Forms.ListView();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblSelectedValue = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblRemarksValue = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
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
            this.lblTitle.Location = new System.Drawing.Point(192, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(269, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Documents";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.Color.Gray;
            this.lblInstructions.Location = new System.Drawing.Point(167, 49);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(327, 22);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "Upload your required documents below.";
            // 
            // lvDocuments
            // 
            this.lvDocuments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvDocuments.FullRowSelect = true;
            this.lvDocuments.GridLines = true;
            this.lvDocuments.HideSelection = false;
            this.lvDocuments.Location = new System.Drawing.Point(17, 74);
            this.lvDocuments.Name = "lvDocuments";
            this.lvDocuments.Size = new System.Drawing.Size(640, 280);
            this.lvDocuments.TabIndex = 2;
            this.lvDocuments.UseCompatibleStateImageBehavior = false;
            this.lvDocuments.View = System.Windows.Forms.View.Details;
            this.lvDocuments.SelectedIndexChanged += new System.EventHandler(this.lvDocuments_SelectedIndexChanged);
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(12, 357);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(207, 25);
            this.lblSelected.TabIndex = 3;
            this.lblSelected.Text = "Selected Document:";
            // 
            // lblSelectedValue
            // 
            this.lblSelectedValue.AutoSize = true;
            this.lblSelectedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedValue.Location = new System.Drawing.Point(225, 357);
            this.lblSelectedValue.Name = "lblSelectedValue";
            this.lblSelectedValue.Size = new System.Drawing.Size(19, 25);
            this.lblSelectedValue.TabIndex = 4;
            this.lblSelectedValue.Text = "-";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(12, 383);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(103, 25);
            this.lblRemarks.TabIndex = 5;
            this.lblRemarks.Text = "Remarks:";
            // 
            // lblRemarksValue
            // 
            this.lblRemarksValue.AutoSize = true;
            this.lblRemarksValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarksValue.ForeColor = System.Drawing.Color.Gray;
            this.lblRemarksValue.Location = new System.Drawing.Point(225, 383);
            this.lblRemarksValue.Name = "lblRemarksValue";
            this.lblRemarksValue.Size = new System.Drawing.Size(19, 25);
            this.lblRemarksValue.TabIndex = 6;
            this.lblRemarksValue.Text = "-";
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(17, 430);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(183, 32);
            this.btnUpload.TabIndex = 7;
            this.btnUpload.Text = "Upload Document";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(569, 430);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 32);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Requirement";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Name";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Uploaded At";
            this.columnHeader4.Width = 130;
            // 
            // MyDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(678, 494);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblRemarksValue);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblSelectedValue);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lvDocuments);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MyDocumentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Documents";
            this.Load += new System.EventHandler(this.MyDocumentsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.ListView lvDocuments;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblSelectedValue;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblRemarksValue;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBack;
    }
}