using Microsoft.AspNetCore.Mvc;
using Symphony_V2.Infrastructure.Models;
using Symphony_V2.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Symphony_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;
        public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            try
            {
                var questions = await _questionnaireRepository.GetQuestions();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{questionnaireId}")]
        public async Task<IActionResult> CheckQuestionnaire(int questionnaireId)
        {
            try
            {
                var result = await _questionnaireRepository.CheckQuestionnaire(questionnaireId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("PostQuestions")]
        public async Task<IActionResult> PostQuestions(List<QuestionAnswer> questionAnswers)
        {
            try
            {
                var result = _questionnaireRepository.PostAnswers(questionAnswers);
                if (result)
                {
                    return Ok(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("VerifyUser")]
        public async Task<IActionResult> VerifyUser(Questionnaire questionnaire)
        {
            try
            {
                var result = _questionnaireRepository.VerifyPin(questionnaire);
                if (result)
                {
                    return Ok(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
    }
}
