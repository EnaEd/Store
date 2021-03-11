namespace Store.Shared.Constants
{
    public partial class Constant
    {

        public class Common
        {
            public const int ARRAY_INDEX_OFFSET = 1;

            public const string MAIL_SUBJECT_TEXT = "Verification mail";
            public const string MAIL_MESSAGE_FORGOT_PASSWORD_TEXT = "your new password <br> <div> {0} <div/>";
            public const string MAIL_MESSAGE_CONFIRM_EMAIL_TEXT = "click this link for confirm registration <br> <a href='{0}'> Confirm mail <a/>";
            public const string MAIL_PARAM_CODE = "code";
            public const string MAIL_PARAM_EMAIL = "email";
            public const string MAIL_CALLBACK_URL = "http://localhost:56932/api/account/confirmemail";
            public const int DEFAULT_PAGE_OFFSET = 1;
        }
    }
}
