using Microsoft.EntityFrameworkCore;
using Symphony_V2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony_V2.Infrastructure.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly Context _context;

        public QuestionnaireRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<Question>> GetQuestions()
        {
            return await _context.Questions.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<bool> CheckQuestionnaire(int questionnaireId)
        {
            var questionnare = _context.QuestionAnswers.Where(x => x.QuestionnaireId == questionnaireId).FirstOrDefault();
            if (questionnare != null)
            {
                return true;
            }
            return false;
        }


        public bool PostAnswers(List<QuestionAnswer> questionAnswers)
        {
            try
            {
                _context.QuestionAnswers.AddRange(questionAnswers);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //TODO Log error
                return false;
            }
        }

        public bool VerifyPin(Questionnaire questionnaire)
        {
            var isValid = _context.Questionnaires.Where(x => x.Id == questionnaire.Id && x.Pin == questionnaire.Pin).FirstOrDefault();
            if (isValid != null)
            {
                return true; 
            }
            return false;
        }
    }
}
