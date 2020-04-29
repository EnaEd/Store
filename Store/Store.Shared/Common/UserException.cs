using System;
using static Store.Shared.Enums.Enums;

namespace Store.Shared.Common
{
    public class UserException : Exception
    {
        public ErrorCode Code { get; set; }
        public string Description { get; set; }
        public UserException(string description, ErrorCode errorCode = ErrorCode.InternalServerError)
        {
            Code = errorCode;
            Description = description;
        }
    }
}
