namespace postgres_database_restore_tool.Constants
{
    internal static class CommandTypeConstants
    {
        public static (string key, string value) PgRestore = ("PG Restore", "pg_restore");
        public static (string key, string value) PgDump = ("PG Dump", "pg_dump");
    }
}