using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using PG_Administrator.ValueObject;

namespace PG_Administrator
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

        private void OnFileOpenClick(object sender, EventArgs e)
        {
            var selected = TargetLocation.ShowDialog();
            if (selected == DialogResult.OK)
            {
                MessageBox.Show(TargetLocation.FileName);
            }
        }

        private void OnRestore(object sender, EventArgs e)
        {
            try
            {
                var username = UserNameElm.Text;
                var password = PasswordElm.Text;
                var databaseName = DatabaseElem.Text;
                var databaseLocation = TargetLocation.FileName;
                var databaseBackupType = TypeSelectorElem.SelectedValue.ToString();
                var actionTypeValue = ActionSelectorElem.SelectedValue.ToString();
                Environment.SetEnvironmentVariable(pwdKey, password);

                switch (actionTypeValue)
                {
                    case "Drop_and_Restore":
                        ActionToPerform(new CommandAndConnectionVo()
                        {
                            Database = databaseName,
                            User = username,
                            Type = "drop"
                        });

                        ActionToPerform(new CommandAndConnectionVo()
                        {
                            Database = databaseName,
                            User = username,
                            Type = "create"
                        });
                        break;
                    case "Create_and_Restore":
                        ActionToPerform(new CommandAndConnectionVo()
                        {
                            Database = databaseName,
                            User = username,
                            Type = "create"
                        });
                        break;
                }

                var proc = new Process();
                if (databaseBackupType == "pg_dump")
                {
                    proc.StartInfo.FileName = "psql";
                    proc.StartInfo.Arguments = $@"-U {username} ""{databaseName}"" < ""{databaseLocation}""";
                }
                else
                {
                    proc.StartInfo.FileName = databaseBackupType;
                    proc.StartInfo.Arguments = $@"-U {username} -d ""{databaseName}"" ""{databaseLocation}""";
                }

                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                var output = proc.StandardOutput.ReadToEnd();
                var error = proc.StandardError.ReadToEnd();
                proc.WaitForExit();
                if (proc.ExitCode != 0)
                {
                    proc.Close();
                    throw new Exception("Error restoring database.Details: " + error);
                }

                proc.Close();
                MessageBox.Show("Database restore successfully");
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

        private static void ActionToPerform(CommandAndConnectionVo vo)
        {
            const string pwdKey = "PGPASSWORD";
            var proc = new Process();
            proc.StartInfo.FileName = "psql";
            proc.StartInfo.Arguments = $@"-U {vo.User} -c ""{vo.Type} database """"{vo.Database}""""";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            var output = proc.StandardOutput.ReadToEnd();
            var error = proc.StandardError.ReadToEnd();
            proc.WaitForExit();
            if (proc.ExitCode != 0)
            {
                proc.Close();
                throw new Exception("Error restoring database: " + error);
            }

            proc.Close();
        }
    }
}