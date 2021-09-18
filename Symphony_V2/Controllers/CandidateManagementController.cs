using Microsoft.AspNetCore.Mvc;
using Symphony_V2.Infrastructure.Models;
using Symphony_V2.Infrastructure.Repositories;
using Symphony_V2.Services.Interfaces;
using Symphony_V2.Services.Models;
using System;
using System.Threading.Tasks;

namespace Symphony_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateManagementController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestionnaireRepository _questionnaireRepository;
        private readonly IMailService _mailService;
        public CandidateManagementController(IUserRepository userRepository, IQuestionnaireRepository questionnaireRepository, IMailService mailService)
        {
            _userRepository = userRepository;
            _questionnaireRepository = questionnaireRepository;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userRepository.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpDelete]
        [Route("{userGuid}")]
        public async Task<IActionResult> Delete(Guid userGuid)
        {
            try
            {
                _userRepository.RemoveUser(userGuid);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            try
            {
                user.Questionnaire = PrepareQuestionnaire();
                var result = _userRepository.CreateUser(user);

                if (result.Questionnaire != null)
                {
                    var mailRequest = new MailRequest
                    {
                        ToEmail = result.Email,
                        UserFirstName = result.FirstName,
                        UserLastName = result.LastName,
                        QuestionnairePin = result.Questionnaire.Pin,
                        QuestionnaireUrl = $"https://localhost:44381/questionnaire-verify/{result.Questionnaire.Id}"
                    };

                    await _mailService.SendEmailAsync(mailRequest);
                }
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private Questionnaire PrepareQuestionnaire()
        {
            Random random = new Random();
            return new Questionnaire
            {
                Pin = random.Next(1000, 9999).ToString()
            };
        }
    }
}
