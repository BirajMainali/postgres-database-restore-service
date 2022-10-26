using System;
using postgres_database_restore_tool.ValueObject;

namespace postgres_database_restore_tool.Validator
{
    public static class UserConnectionValidator
    {
        public static UserConnectionVo Validate(this UserConnectionVo connectionVo)
        {
            if (string.IsNullOrEmpty(connectionVo.UserName))
            {
                throw new Exception("UserName can not be null");
            }

            if (string.IsNullOrEmpty(connectionVo.Password))
            {
                throw new Exception("Password can not be null");
            }

            if (string.IsNullOrEmpty(connectionVo.DatabaseName))
            {
                throw new Exception("Database name can not be null");
            }

            if (string.IsNullOrEmpty(connectionVo.RestoreFileLocation))
            {
                throw new Exception("Restore file is not selected");
            }
            
            if (string.IsNullOrEmpty(connectionVo.ActionTypeValue))
            {
                throw new Exception("Please select action type");
            }

            return connectionVo;
        }
    }
}