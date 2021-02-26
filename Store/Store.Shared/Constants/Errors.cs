namespace Store.Shared.Constants
{
    public partial class Constant
    {

        public static class Errors
        {

            public const string SERVER_ERROR = "something went wrong please call to admin";

            public const string USER_NOT_EXISTS = "user not exists";

            public const string REFRESH_TOKEN_NOT_CONFIRM = "refresh token not confirm";
            public const string WRONG_EMAIL_ERROR = "wrong email";
            public const string WRONG_PASSWORD_ERROR = "wrong password";
            public const string CONFIRM_EMAIL_FAIL = "fail on confirm email";
            public const string EMAIL_NOT_CONFIRM = "email not confirm";
            public const string SIGNOUT_FAIL = "fail on signout";
            public const string GENERATE_TOKEN_FAIL = "fail on generaet token";

            public const string EMPTY_FIELD = "empty field";

            public const string CREATE_USER_FAIL = "fail on user create";
            public const string ADD_TO_ROLE_FAIL = "fail on user to role";
            public const string RESET_PASSWORD_FAIL = "fail on reset password";

            public const string AUTHOR_NOT_FOUND = "author not found";
            public const string AUTHOR_CREATE_FAIL = "fail on author create";
            public const string AUTHOR_ALREADY_EXISTS = "author with same name already exists";

            public const string CREATE_EDITION_FAIL = "cann't create empty edition";
            public const string UPDATE_EDITION_FAIL = "no data for update";
            public const string DELETE_EDITION_FAIL = "no data for deleting";

        }
    }
}
