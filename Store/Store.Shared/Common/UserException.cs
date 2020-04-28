using Store.Shared.Enums;
using System;

namespace Store.Shared.Common
{
    public class UserException : Exception
    {
        public ErrorCode Code { get; set; } = ErrorCode.InternalServerError;
        public string Description { get; set; }
    }
}
