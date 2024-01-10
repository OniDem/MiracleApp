namespace DTO.Mail
{
    public class SendCodeRequest
    {
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Code { get; set; }
    }
}
