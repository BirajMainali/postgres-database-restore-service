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
using System.Threading;

namespace postgres_database_restore_tool
{
    public partial class PgAdmin : Form
    {
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
            LoadPostgresUserData();

            CancelRestoreButton.Visible = false;

            var commandType = new List<string>()
            {
                CommandTypeConstants.PgRestore,
                CommandTypeConstants.PgDump
            };
            var actionTypes = new List<string>()
            {
                ActionTypeConstants.DropAndRestore,
                ActionTypeConstants.CreateAndRestore,
            };
            ActionSelectorElem.DataSource = actionTypes;
            TypeSelectorElem.DataSource = commandType;
        }

        private void LoadPostgresUserData()
        {
            UserNameElm.Text = Settings.Default.PostgresUserName;
            PasswordElm.Text = Settings.Default.PostgresPassword;
        }

        private void OnFileOpenClick(object sender, EventArgs e)
        {
            var selected = TargetLocation.ShowDialog();
            if (selected == DialogResult.OK)
            {
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

        private Thread _backgroundWorkerThread;
        
        private void OnRestore(object sender, EventArgs e)
        {
            try
            {
                SaveUserAndPassword();

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

                RestoreBtn.Text = "⚒ Restoring...";
                RestoreBtn.Click -= OnRestore;
                var bgw = new BackgroundWorker();
                               

                CancelRestoreButton.Visible = true;
                CancelRestoreButton.Click += (object _,EventArgs ex) => {
                    AbortBackgroundWorker();
                };

                void AbortBackgroundWorker()
                {
                    if (_backgroundWorkerThread != null)
                    {
                        _backgroundWorkerThread.Abort();
                        RestoreBtn.Text = "✖ Restore Cancelled";
                        EndLoading();
                        FinalizeLoadingFinished();
                    }
                }

                bgw.DoWork += (object _, DoWorkEventArgs args) =>
                {
                    try
                    {
                        _backgroundWorkerThread = Thread.CurrentThread;                        
                        CommandExecutor.ExecuteRestore(connection);
                    }
                    catch (ThreadAbortException)
                    {
                        //clean up after thread has aborted.
                        throw;
                    }
                };

                
                bgw.RunWorkerCompleted += (object _, RunWorkerCompletedEventArgs args) =>
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
                bgw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ola =>"+ex.Message);
                FinalizeLoadingFinished();
            }
            finally
            {
                Environment.SetEnvironmentVariable(PostgresConstants.PasswordKey, string.Empty);
            }
        }

        private void FinalizeLoadingFinished()
        {
            EndLoading();
            SelectedFilelbl.Text = "No file Selected";
            RestoreBtn.Text = "⚒ Restore";
            CancelRestoreButton.Visible = false;
            RestoreBtn.Click += OnRestore;            
        }

        private void SaveUserAndPassword()
        {
            Settings.Default.PostgresUserName = UserNameElm.Text;
            Settings.Default.PostgresPassword = PasswordElm.Text;
            Settings.Default.Save();
        }
    }
}