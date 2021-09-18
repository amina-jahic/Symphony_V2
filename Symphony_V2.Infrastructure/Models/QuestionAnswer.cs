namespace Symphony_V2.Infrastructure.Models
{
    public class QuestionAnswer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int AnswerValue { get; set; }

        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }

    }
}
