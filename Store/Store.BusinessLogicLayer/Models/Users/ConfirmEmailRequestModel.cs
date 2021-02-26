namespace Store.BusinessLogicLayer.Models.Users
{
    public class ConfirmEmailRequestModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
