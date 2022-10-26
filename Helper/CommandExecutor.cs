using System;
using System.Diagnostics;
using postgres_database_restore_tool.Constants;
using postgres_database_restore_tool.ValueObject;

namespace postgres_database_restore_tool.Helper
{
    public static class CommandExecutor
    {
        public static void Execute(string commandType, string user, string database)
        {
            var fileName = "psql";
            var arguments = $@"-U {user} -c ""{commandType} database """"{database}""""";

            var process = ExecuteCommand(fileName, arguments);
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                process.Close();
                throw new Exception("Error restoring database: " + error);
            }
            process.Close();
        }

        public static void ExecuteRestore(UserConnectionVo connection)
        {
            Environment.SetEnvironmentVariable(PostgresConstants.PasswordKey, connection.Password);
            switch (connection.ActionTypeValue)
            {
                case ActionTypeConstants.DropAndRestore:
                    Execute("drop", connection.UserName, connection.DatabaseName);
                    Execute("create", connection.UserName, connection.DatabaseName);
                    break;
                case ActionTypeConstants.CreateAndRestore:
                    Execute("create", connection.UserName, connection.DatabaseName);
                    break;
            }


            string fileName;
            string arguments;

            if (connection.IsForPgDump)
            {
                fileName = "psql";
                arguments = $@"-U {connection.UserName} ""{connection.DatabaseName}"" < ""{connection.RestoreFileLocation}""";
            }
            else
            {
                fileName = "pg_dump";
                arguments = $@"-U {connection.UserName} -d ""{connection.DatabaseName}"" ""{connection.RestoreFileLocation}""";
            }

            var process = ExecuteCommand(fileName, arguments);
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                process.Close();
                throw new Exception("Error restoring database.Details: " + error);
            }
            process.Close();
        }

        private static Process ExecuteCommand(string fileName, string arguments)
        {
            var proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.Arguments = arguments;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            return proc;
        }
    }
}