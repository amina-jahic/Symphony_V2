using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony_V2.Infrastructure.Models
{
    public class User
    {
        public Guid Guid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Code { get; set; }

        public int Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Questionnaire Questionnaire { get; set; }
    }
}
