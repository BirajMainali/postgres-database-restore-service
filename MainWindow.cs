using System;
using System.Collections.Generic;
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
                MessageBox.Show(TargetLocation.FileName);
                SelectedFilelbl.Text = TargetLocation.FileName;
            }
        }

        private void OnRestore(object sender, EventArgs e)
        {
            try
            {

                
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
                CommandExecutor.ExecuteRestore(connection);
                WorkingStatus.Text = "Completed";
                MessageBox.Show($"Database #{DatabaseElem.Text} restored successfully");
                SelectedFilelbl.Text = "";
                WorkingStatus.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Environment.SetEnvironmentVariable(pwdKey, "");
            }
        }

    }
}