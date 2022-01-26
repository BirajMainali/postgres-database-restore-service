namespace postgres_database_restore_tool
{
    partial class PgAdmin
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
            this.UserLbl = new System.Windows.Forms.Label();
            this.UserNameElm = new System.Windows.Forms.TextBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.PasswordElm = new System.Windows.Forms.TextBox();
            this.TypeSelectorElem = new System.Windows.Forms.ComboBox();
            this.TypeLbl = new System.Windows.Forms.Label();
            this.RestoreBtn = new System.Windows.Forms.Button();
            this.TargetLocation = new System.Windows.Forms.OpenFileDialog();
            this.FileOpenElem = new System.Windows.Forms.Button();
            this.DatabaseElem = new System.Windows.Forms.TextBox();
            this.DbNamelbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ActionSelectorElem = new System.Windows.Forms.ComboBox();
            this.StatusElem = new System.Windows.Forms.Label();
            this.WorkingStatus = new System.Windows.Forms.Label();
            this.SelectedFilelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserLbl
            // 
            this.UserLbl.AutoSize = true;
            this.UserLbl.Location = new System.Drawing.Point(104, 45);
            this.UserLbl.Name = "UserLbl";
            this.UserLbl.Size = new System.Drawing.Size(82, 13);
            this.UserLbl.TabIndex = 0;
            this.UserLbl.Text = "Postgres User : ";
            // 
            // UserNameElm
            // 
            this.UserNameElm.Location = new System.Drawing.Point(183, 42);
            this.UserNameElm.Name = "UserNameElm";
            this.UserNameElm.Size = new System.Drawing.Size(233, 20);
            this.UserNameElm.TabIndex = 1;
            this.UserNameElm.Text = "postgres";
            this.UserNameElm.UseWaitCursor = true;
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Location = new System.Drawing.Point(114, 71);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(59, 13);
            this.PasswordLbl.TabIndex = 2;
            this.PasswordLbl.Text = "Password :";
            // 
            // PasswordElm
            // 
            this.PasswordElm.Location = new System.Drawing.Point(183, 68);
            this.PasswordElm.Name = "PasswordElm";
            this.PasswordElm.Size = new System.Drawing.Size(233, 20);
            this.PasswordElm.TabIndex = 3;
            this.PasswordElm.Text = "admin";
            // 
            // TypeSelectorElem
            // 
            this.TypeSelectorElem.FormattingEnabled = true;
            this.TypeSelectorElem.Location = new System.Drawing.Point(183, 120);
            this.TypeSelectorElem.Name = "TypeSelectorElem";
            this.TypeSelectorElem.Size = new System.Drawing.Size(231, 21);
            this.TypeSelectorElem.TabIndex = 4;
            // 
            // TypeLbl
            // 
            this.TypeLbl.AutoSize = true;
            this.TypeLbl.Location = new System.Drawing.Point(126, 120);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new System.Drawing.Size(37, 13);
            this.TypeLbl.TabIndex = 5;
            this.TypeLbl.Text = "Type :";
            // 
            // RestoreBtn
            // 
            this.RestoreBtn.Location = new System.Drawing.Point(244, 193);
            this.RestoreBtn.Name = "RestoreBtn";
            this.RestoreBtn.Size = new System.Drawing.Size(170, 48);
            this.RestoreBtn.TabIndex = 6;
            this.RestoreBtn.Text = "Restore";
            this.RestoreBtn.UseVisualStyleBackColor = true;
            // 
            // TargetLocation
            // 
            this.TargetLocation.FileName = "FileSelector";
            // 
            // FileOpenElem
            // 
            this.FileOpenElem.Location = new System.Drawing.Point(142, 195);
            this.FileOpenElem.Name = "FileOpenElem";
            this.FileOpenElem.Size = new System.Drawing.Size(96, 44);
            this.FileOpenElem.TabIndex = 7;
            this.FileOpenElem.Text = "Choose file";
            this.FileOpenElem.UseVisualStyleBackColor = true;
            // 
            // DatabaseElem
            // 
            this.DatabaseElem.Location = new System.Drawing.Point(183, 94);
            this.DatabaseElem.Name = "DatabaseElem";
            this.DatabaseElem.Size = new System.Drawing.Size(233, 20);
            this.DatabaseElem.TabIndex = 8;
            // 
            // DbNamelbl
            // 
            this.DbNamelbl.AutoSize = true;
            this.DbNamelbl.Location = new System.Drawing.Point(114, 94);
            this.DbNamelbl.Name = "DbNamelbl";
            this.DbNamelbl.Size = new System.Drawing.Size(59, 13);
            this.DbNamelbl.TabIndex = 9;
            this.DbNamelbl.Text = "Database :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Action";
            // 
            // ActionSelectorElem
            // 
            this.ActionSelectorElem.FormattingEnabled = true;
            this.ActionSelectorElem.Location = new System.Drawing.Point(183, 148);
            this.ActionSelectorElem.Name = "ActionSelectorElem";
            this.ActionSelectorElem.Size = new System.Drawing.Size(231, 21);
            this.ActionSelectorElem.TabIndex = 12;
            // 
            // StatusElem
            // 
            this.StatusElem.AutoSize = true;
            this.StatusElem.Location = new System.Drawing.Point(241, 265);
            this.StatusElem.Name = "StatusElem";
            this.StatusElem.Size = new System.Drawing.Size(0, 13);
            this.StatusElem.TabIndex = 13;
            // 
            // WorkingStatus
            // 
            this.WorkingStatus.AutoSize = true;
            this.WorkingStatus.Location = new System.Drawing.Point(241, 278);
            this.WorkingStatus.Name = "WorkingStatus";
            this.WorkingStatus.Size = new System.Drawing.Size(0, 13);
            this.WorkingStatus.TabIndex = 14;
            // 
            // SelectedFilelbl
            // 
            this.SelectedFilelbl.AutoSize = true;
            this.SelectedFilelbl.Location = new System.Drawing.Point(139, 251);
            this.SelectedFilelbl.Name = "SelectedFilelbl";
            this.SelectedFilelbl.Size = new System.Drawing.Size(0, 13);
            this.SelectedFilelbl.TabIndex = 15;
            // 
            // PgAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 336);
            this.Controls.Add(this.SelectedFilelbl);
            this.Controls.Add(this.WorkingStatus);
            this.Controls.Add(this.StatusElem);
            this.Controls.Add(this.ActionSelectorElem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DbNamelbl);
            this.Controls.Add(this.DatabaseElem);
            this.Controls.Add(this.FileOpenElem);
            this.Controls.Add(this.RestoreBtn);
            this.Controls.Add(this.TypeLbl);
            this.Controls.Add(this.TypeSelectorElem);
            this.Controls.Add(this.PasswordElm);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.UserNameElm);
            this.Controls.Add(this.UserLbl);
            this.Name = "PgAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postgres Database Restore Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserLbl;
        private System.Windows.Forms.TextBox UserNameElm;
        private System.Windows.Forms.Label PasswordLbl;
        private System.Windows.Forms.TextBox PasswordElm;
        private System.Windows.Forms.ComboBox TypeSelectorElem;
        private System.Windows.Forms.Label TypeLbl;
        private System.Windows.Forms.Button RestoreBtn;
        private System.Windows.Forms.OpenFileDialog TargetLocation;
        private System.Windows.Forms.Button FileOpenElem;
        private System.Windows.Forms.TextBox DatabaseElem;
        private System.Windows.Forms.Label DbNamelbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ActionSelectorElem;
        private System.Windows.Forms.Label StatusElem;
        private System.Windows.Forms.Label WorkingStatus;
        private System.Windows.Forms.Label SelectedFilelbl;
    }
}

