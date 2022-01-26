using System;
using System.Diagnostics;
using postgres_database_restore_tool.ValueObject;

namespace postgres_database_restore_tool.Helper
{
    public static class CommandExecutor
    {
        public static void Execute(string commandType, string user, string database)
        {
            var proc = new Process();
            proc.StartInfo.FileName = "psql";
            proc.StartInfo.Arguments = $@"-U {user} -c ""{commandType} database """"{database}""""";
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

        public static void ExecuteRestore(UserConnectionVo connection)
        {
            const string pwdKey = "PGPASSWORD";
            Environment.SetEnvironmentVariable(pwdKey, connection.Password);
            switch (connection.ActionTypeValue)
            {
                case "Drop_and_Restore":
                    Execute("drop", connection.UserName, connection.DatabaseName);
                    Execute("create", connection.UserName, connection.DatabaseName);
                    break;
                case "Create_and_Restore":
                    Execute("create", connection.UserName, connection.DatabaseName);
                    break;
            }

            var proc = new Process();
            if (connection.DatabaseBackupType == "pg_dump")
            {
                proc.StartInfo.FileName = "psql";
                proc.StartInfo.Arguments = $@"-U {connection.UserName} ""{connection.DatabaseName}"" < ""{connection.RestoreFileLocation}""";
            }
            else
            {
                proc.StartInfo.FileName = connection.DatabaseBackupType;
                proc.StartInfo.Arguments = $@"-U {connection.UserName} -d ""{connection.DatabaseName}"" ""{connection.RestoreFileLocation}""";
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
        }
    }
}