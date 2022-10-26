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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PgAdmin));
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
            this.SelectedFilelbl = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadingBar = new System.Windows.Forms.ToolStripProgressBar();
            this.loadingLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WorkingStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rememberPassword = new System.Windows.Forms.CheckBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserLbl
            // 
            this.UserLbl.AutoSize = true;
            this.UserLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLbl.Location = new System.Drawing.Point(61, 114);
            this.UserLbl.Name = "UserLbl";
            this.UserLbl.Size = new System.Drawing.Size(122, 20);
            this.UserLbl.TabIndex = 0;
            this.UserLbl.Text = "Postgres User : ";
            // 
            // UserNameElm
            // 
            this.UserNameElm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameElm.Location = new System.Drawing.Point(198, 112);
            this.UserNameElm.Name = "UserNameElm";
            this.UserNameElm.Size = new System.Drawing.Size(367, 26);
            this.UserNameElm.TabIndex = 1;
            this.UserNameElm.Text = "postgres";
            this.UserNameElm.UseWaitCursor = true;
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLbl.Location = new System.Drawing.Point(97, 154);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(86, 20);
            this.PasswordLbl.TabIndex = 2;
            this.PasswordLbl.Text = "Password :";
            // 
            // PasswordElm
            // 
            this.PasswordElm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordElm.Location = new System.Drawing.Point(198, 150);
            this.PasswordElm.Name = "PasswordElm";
            this.PasswordElm.PasswordChar = '*';
            this.PasswordElm.Size = new System.Drawing.Size(243, 26);
            this.PasswordElm.TabIndex = 3;
            this.PasswordElm.Text = "admin";
            // 
            // TypeSelectorElem
            // 
            this.TypeSelectorElem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeSelectorElem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeSelectorElem.FormattingEnabled = true;
            this.TypeSelectorElem.Location = new System.Drawing.Point(198, 226);
            this.TypeSelectorElem.Name = "TypeSelectorElem";
            this.TypeSelectorElem.Size = new System.Drawing.Size(365, 28);
            this.TypeSelectorElem.TabIndex = 4;
            // 
            // TypeLbl
            // 
            this.TypeLbl.AutoSize = true;
            this.TypeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeLbl.Location = new System.Drawing.Point(132, 234);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new System.Drawing.Size(51, 20);
            this.TypeLbl.TabIndex = 5;
            this.TypeLbl.Text = "Type :";
            // 
            // RestoreBtn
            // 
            this.RestoreBtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.RestoreBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreBtn.ForeColor = System.Drawing.Color.White;
            this.RestoreBtn.Location = new System.Drawing.Point(198, 344);
            this.RestoreBtn.Name = "RestoreBtn";
            this.RestoreBtn.Size = new System.Drawing.Size(367, 47);
            this.RestoreBtn.TabIndex = 6;
            this.RestoreBtn.Text = "⚒ Restore";
            this.RestoreBtn.UseVisualStyleBackColor = false;
            // 
            // TargetLocation
            // 
            this.TargetLocation.FileName = "FileSelector";
            // 
            // FileOpenElem
            // 
            this.FileOpenElem.BackColor = System.Drawing.Color.CornflowerBlue;
            this.FileOpenElem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileOpenElem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileOpenElem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FileOpenElem.Location = new System.Drawing.Point(521, 307);
            this.FileOpenElem.Name = "FileOpenElem";
            this.FileOpenElem.Size = new System.Drawing.Size(42, 32);
            this.FileOpenElem.TabIndex = 7;
            this.FileOpenElem.Text = "📂";
            this.FileOpenElem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FileOpenElem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.FileOpenElem.UseVisualStyleBackColor = false;
            // 
            // DatabaseElem
            // 
            this.DatabaseElem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseElem.Location = new System.Drawing.Point(198, 188);
            this.DatabaseElem.Name = "DatabaseElem";
            this.DatabaseElem.Size = new System.Drawing.Size(367, 26);
            this.DatabaseElem.TabIndex = 8;
            // 
            // DbNamelbl
            // 
            this.DbNamelbl.AutoSize = true;
            this.DbNamelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DbNamelbl.Location = new System.Drawing.Point(96, 194);
            this.DbNamelbl.Name = "DbNamelbl";
            this.DbNamelbl.Size = new System.Drawing.Size(87, 20);
            this.DbNamelbl.TabIndex = 9;
            this.DbNamelbl.Text = "Database :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Action :";
            // 
            // ActionSelectorElem
            // 
            this.ActionSelectorElem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionSelectorElem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionSelectorElem.FormattingEnabled = true;
            this.ActionSelectorElem.Location = new System.Drawing.Point(198, 267);
            this.ActionSelectorElem.Name = "ActionSelectorElem";
            this.ActionSelectorElem.Size = new System.Drawing.Size(365, 28);
            this.ActionSelectorElem.TabIndex = 12;
            // 
            // SelectedFilelbl
            // 
            this.SelectedFilelbl.BackColor = System.Drawing.SystemColors.Control;
            this.SelectedFilelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFilelbl.Location = new System.Drawing.Point(198, 311);
            this.SelectedFilelbl.Name = "SelectedFilelbl";
            this.SelectedFilelbl.Size = new System.Drawing.Size(317, 26);
            this.SelectedFilelbl.TabIndex = 15;
            this.SelectedFilelbl.Text = "No File Selected";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingBar,
            this.loadingLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(650, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loadingBar
            // 
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(150, 16);
            this.loadingBar.Step = 50;
            this.loadingBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadingBar.ToolTipText = "Performing task...";
            this.loadingBar.Visible = false;
            // 
            // loadingLbl
            // 
            this.loadingLbl.Name = "loadingLbl";
            this.loadingLbl.Size = new System.Drawing.Size(59, 17);
            this.loadingLbl.Text = "Loading ..";
            this.loadingLbl.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 85);
            this.panel1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(97, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Postgres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(94, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(521, 37);
            this.label3.TabIndex = 19;
            this.label3.Text = "DATABASE RESTORE SERVICE";
            // 
            // WorkingStatus
            // 
            this.WorkingStatus.AutoSize = true;
            this.WorkingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkingStatus.Location = new System.Drawing.Point(12, 367);
            this.WorkingStatus.Name = "WorkingStatus";
            this.WorkingStatus.Size = new System.Drawing.Size(85, 24);
            this.WorkingStatus.TabIndex = 14;
            this.WorkingStatus.Text = " Working";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "File :";
            // 
            // rememberPassword
            // 
            this.rememberPassword.AutoSize = true;
            this.rememberPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberPassword.Location = new System.Drawing.Point(458, 152);
            this.rememberPassword.Name = "rememberPassword";
            this.rememberPassword.Size = new System.Drawing.Size(107, 24);
            this.rememberPassword.TabIndex = 19;
            this.rememberPassword.Text = "Remember";
            this.tooltip.SetToolTip(this.rememberPassword, "Remember Password.");
            this.rememberPassword.UseVisualStyleBackColor = true;
            this.rememberPassword.CheckedChanged += new System.EventHandler(this.RememberPassword_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::postgres_database_restore_tool.Properties.Resources.postgres_database_restore_icon;
            this.pictureBox1.Location = new System.Drawing.Point(25, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PgAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(650, 429);
            this.Controls.Add(this.rememberPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.SelectedFilelbl);
            this.Controls.Add(this.WorkingStatus);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PgAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postgres Database Restore Service";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.TextBox SelectedFilelbl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar loadingBar;
        private System.Windows.Forms.ToolStripStatusLabel loadingLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label WorkingStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox rememberPassword;
        private System.Windows.Forms.ToolTip tooltip;
    }
}

