using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using postgres_database_restore_tool.Helper;
using postgres_database_restore_tool.Validator;
using postgres_database_restore_tool.ValueObject;
using postgres_database_restore_tool.Constants;
using postgres_database_restore_tool.Properties;

namespace postgres_database_restore_tool
{
    public partial class PgAdmin : Form
    {
        private bool isRestoring = false;

        public PgAdmin()
        {
            InitializeComponent();

            WorkingStatus.Text = "";
            AddEventHandlers();
        }

        private void StartLoading(string msg)
        {
            loadingLbl.Text = msg;
            loadingLbl.Visible = true;
            loadingBar.Visible = true;
            RestoreBtn.Text = "⚒ Restoring...";
        }

        private void EndLoading()
        {
            loadingLbl.Text = "";
            loadingLbl.Visible = false;
            loadingBar.Visible = false;
        }

        private void AddEventHandlers()
        {
            Load += OnFormLoad;
            RestoreBtn.Click += OnRestore;
            FileOpenElem.Click += OnFileOpenClick;
        }


        private void OnFormLoad(object sender, EventArgs e)
        {
            ApplyTheme();

            LoadPostgresUserData();

            var commandType = new List<string>()
            {
                CommandTypeConstants.PgRestore.key,
                CommandTypeConstants.PgDump.key
            };
            var actionTypes = new List<string>()
            {
                ActionTypeConstants.DropAndRestore,
                ActionTypeConstants.CreateAndRestore,
            };
            ActionSelectorElem.DataSource = actionTypes;
            TypeSelectorElem.DataSource = commandType;
        }

        private void ApplyTheme()
        {
            label4.ApplyRegularFont();
            label3.ApplyBoldFont();
            label2.ApplyRegularFont();
            UserLbl.ApplyRegularFont();
            PasswordLbl.ApplyRegularFont();
            DbNamelbl.ApplyRegularFont();
            TypeLbl.ApplyRegularFont();
            label1.ApplyRegularFont();
            WorkingStatus.ApplyRegularFont();
            UserNameElm.ApplyRegularFont();
            PasswordElm.ApplyRegularFont();
            DatabaseElem.ApplyRegularFont();
            TypeSelectorElem.ApplyRegularFont();
            ActionSelectorElem.ApplyRegularFont();
            SelectedFilelbl.ApplyRegularFont();
            RestoreBtn.ApplyBoldFont();
            FileOpenElem.ApplyRegularFont();
            rememberPassword.ApplyRegularFont();
            statusStrip1.ApplyRegularFont();
        }

        private void LoadPostgresUserData()
        {
            UserNameElm.Text = Settings.Default.PostgresUserName;
            PasswordElm.Text = Settings.Default.PostgresPassword;
        }

        private void OnFileOpenClick(object sender, EventArgs e)
        {
            if (isRestoring) return;

            var selected = TargetLocation.ShowDialog();
            if (selected == DialogResult.OK)
            {
                SelectedFilelbl.Text = TargetLocation.FileName;
                if (string.IsNullOrWhiteSpace(DatabaseElem.Text))
                {
                    var fileName = TargetLocation.FileName.Split(new char[] { '/', '\\' }).LastOrDefault();
                    if (fileName.Contains("_"))
                    {
                        DatabaseElem.Text = fileName.Split('_').FirstOrDefault();
                    }
                }
            }
        }

        private void OnRestore(object sender, EventArgs e)
        {
            try
            {
                var connection = new UserConnectionVo()
                {
                    UserName = UserNameElm.Text.Trim(),
                    Password = PasswordElm.Text.Trim(),
                    DatabaseName = DatabaseElem.Text.Trim(),
                    ActionTypeValue = ActionSelectorElem.SelectedValue.ToString(),
                    IsForPgDump = (TypeSelectorElem.SelectedValue.ToString() == CommandTypeConstants.PgDump.key),
                    RestoreFileLocation = SelectedFilelbl.Text.Trim(),
                }
                .Validate();

                if (isRestoring) return;
                isRestoring = true;

                SaveUserInfo();

                StartLoading("Restoring Database");
                
                var restoreBackgroundworker = new BackgroundWorker();

                restoreBackgroundworker.DoWork += (object _, DoWorkEventArgs args) =>
                {
                    CommandExecutor.ExecuteRestore(connection);
                };

                restoreBackgroundworker.RunWorkerCompleted += (object _, RunWorkerCompletedEventArgs args) =>
                {
                    if (args.Error == null)
                    {
                        RestoreBtn.Text = "✅ Restore Completed";
                        MessageBox.Show($"Database #{DatabaseElem.Text} restored successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var msg = args.Error?.Message ?? "Error during operation";
                        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    FinalizeLoadingFinished();
                };
                restoreBackgroundworker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FinalizeLoadingFinished();
            }
            finally
            {
                Environment.SetEnvironmentVariable(PostgresConstants.PasswordKey, string.Empty);
                isRestoring = false;
            }
        }

        private void FinalizeLoadingFinished()
        {
            EndLoading();
            SelectedFilelbl.Text = string.Empty;
            DatabaseElem.Text = string.Empty;
            RestoreBtn.Text = "⚒ Restore";
            isRestoring = false;
        }

        private void SaveUserInfo()
        {
            Settings.Default.PostgresUserName = UserNameElm.Text;
            Settings.Default.Save();
        }

        private void RememberPassword_CheckedChanged(object sender, EventArgs e)
        {
            var needToRememberPassword = this.rememberPassword.Checked;

            if (needToRememberPassword)
            {
                Settings.Default.PostgresPassword = PasswordElm.Text;
                Settings.Default.Save();
            }
        }
    }
}
