using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using postgres_database_restore_tool.Helper;
using postgres_database_restore_tool.Validator;
using postgres_database_restore_tool.ValueObject;

namespace postgres_database_restore_tool
{
    public partial class PgAdmin : Form
    {
        public PgAdmin()
        {
            InitializeComponent();
            AddEventHandlers();
        }

        private void StartLoading(string msg)
        {
            loadingLbl.Text = msg;
            loadingLbl.Visible = true;
            loadingBar.Visible = true;
        }

        private void EndLoading()
        {
            loadingLbl.Text = "";
            loadingLbl.Visible = false;
            loadingBar.Visible = false;
        }

        const string pwdKey = "PGPASSWORD";

        private void AddEventHandlers()
        {
            Load += OnFormLoad;
            RestoreBtn.Click += OnRestore;
            FileOpenElem.Click += OnFileOpenClick;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            var commandType = new List<string>()
            {
                "pg_restore",
                "pg_dump"
            };
            var actionTypes = new List<string>()
            {
                "Drop_and_Restore",
                "Create_and_Restore",
            };
            ActionSelectorElem.DataSource = actionTypes;
            TypeSelectorElem.DataSource = commandType;
        }

        private void OnFileOpenClick(object sender, EventArgs e)
        {
            var selected = TargetLocation.ShowDialog();
            if (selected == DialogResult.OK)
            {
                MessageBox.Show(TargetLocation.FileName,"File Selected");
                SelectedFilelbl.Text = TargetLocation.FileName;
                if(string.IsNullOrWhiteSpace(DatabaseElem.Text))
                {
                    var fileName = TargetLocation.FileName.Split(new char[] { '/', '\\' }).LastOrDefault();
                    if(fileName.Contains("_"))
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
                StartLoading("Restoring Database");

                var connection = UserConnectionValidator.ValidateConnection(new UserConnectionVo()
                {
                    UserName = UserNameElm.Text,
                    Password = PasswordElm.Text,
                    DatabaseName = DatabaseElem.Text,
                    ActionTypeValue = ActionSelectorElem.SelectedValue.ToString(),
                    DatabaseBackupType = TypeSelectorElem.SelectedValue.ToString(),
                    RestoreFileLocation = TargetLocation.FileName,
                });

                WorkingStatus.Text = "Restoring...";
                var bgw = new BackgroundWorker();
                bgw.DoWork += (object _, DoWorkEventArgs args) =>
                {
                    CommandExecutor.ExecuteRestore(connection);
                };
                bgw.RunWorkerCompleted += (object _, RunWorkerCompletedEventArgs args) =>
                {
                    if(args.Error == null)
                    {
                        WorkingStatus.Text = "Completed";
                        MessageBox.Show($"Database #{DatabaseElem.Text} restored successfully");
                    }
                    else
                    {
                        var msg = (args.Error as Exception)?.Message ?? "Error during operation";
                        MessageBox.Show(msg);
                    }
                    SelectedFilelbl.Text = "";
                    WorkingStatus.Text = "";
                    EndLoading();

                };
                bgw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                EndLoading();
                SelectedFilelbl.Text = "";
                WorkingStatus.Text = "";
                MessageBox.Show(ex.Message);
                Environment.SetEnvironmentVariable(pwdKey, "");
            }
        }

    }
}