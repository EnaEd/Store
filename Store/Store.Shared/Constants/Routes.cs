namespace Store.Shared.Constants
{
    public partial class Constant
    {
        public static class Routes
        {
            public const string DEFAULT_API_ROUTE = "api/[controller]";
            public const string ERROR_ROUTE = "/error";

            //home controller
            public const string TEST_AUTH_ADMIN_ROUTE = "authadmin";
            public const string TEST_AUTH_ROUTE = "auth";

            //admin controller
            public const string GET_USERS_ROUTE = "getfiltereduser";
            public const string BLOCK_USER_ROUTE = "setblockuser";

            //account controller
            public const string GET_ACCOUNTS_ROUTE = "getall";
            public const string SIGN_OUT_ROUTE = "signout";
            public const string CONFIRM_MAIL_ROUTE = "confirmemail";
            public const string SIGN_UP_ROUTE = "signup";
            public const string SIGN_IN_ROUTE = "signin";
            public const string FORGOT_PASSWORD_ROUTE = "forgotpassword";
            public const string REFRESH_TOKEN_ROUTE = "refreshtoken";

            //authorController
            public const string GET_AUTHORS_ROUTE = "getallauthors";
            public const string CREATE_AUTHOR_ROUTE = "createauthor";
            public const string GET_AUTHOR_ROUTE = "getauthor";
            public const string DELETE_AUTHOR_ROUTE = "deleteauthor";
            public const string UPDATE_AUTHOR_ROUTE = "updateauthor";

            //printing edition controller
            public const string GET_EDITIONS_ROUTE = "getedition";
            public const string CREATE_EDITION_ROUTE = "createedition";
            public const string DELETE_EDITION_ROUTE = "deleteedition";
            public const string UPDATE_EDITION_ROUTE = "updateedition";
            public const string PAY_EDITION_ROUTE = "pay";
        }
    }
}
