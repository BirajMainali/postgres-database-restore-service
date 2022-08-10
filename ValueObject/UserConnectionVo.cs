namespace postgres_database_restore_tool.ValueObject
{
    public class UserConnectionVo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public string RestoreFileLocation { get; set; }
        public bool IsForPgDump { get; set; }
        public string ActionTypeValue { get; set; }
        
    }
}