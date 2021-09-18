using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony_V2.Infrastructure.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }

        public string Pin { get; set; }

        public List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
