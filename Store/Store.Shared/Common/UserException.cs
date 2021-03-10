using System;
using System.Collections.Generic;
using static Store.Shared.Enums.Enums;

namespace Store.Shared.Common
{
    public class UserException : Exception
    {
        public ErrorCode Code { get; set; }
        public List<string> Descriptions { get; set; }

        public UserException(string description, ErrorCode errorCode = ErrorCode.InternalServerError)
        {
            Code = errorCode;
            Descriptions = new List<string>() { description };
        }

        public UserException(List<string> descriptions, ErrorCode errorCode = ErrorCode.InternalServerError)
        {
            Code = errorCode;
            Descriptions = descriptions;
        }
    }
}
