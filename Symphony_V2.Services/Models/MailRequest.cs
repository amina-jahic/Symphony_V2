namespace Symphony_V2.Services.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string QuestionnairePin { get; set; }
        public string QuestionnaireUrl { get; set; }
    }
}
