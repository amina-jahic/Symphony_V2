using Symphony_V2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony_V2.Infrastructure.Repositories
{
    public interface IQuestionnaireRepository
    {
        public bool VerifyPin(Questionnaire questionnaire);
        public Task<List<Question>> GetQuestions();
        public bool PostAnswers(List<QuestionAnswer> questionAnswers);

        public Task<bool> CheckQuestionnaire(int questionnaireId);

    }
}
