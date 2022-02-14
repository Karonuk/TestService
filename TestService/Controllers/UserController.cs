using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TestService.DataBase;
using TestService.Services;
using Microsoft.AspNetCore.Authorization;

namespace TestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly IJwtTokenService _tokenService;

        public UserController(EFContext context, IJwtTokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequestViewModel request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (user != null)
            {
                if (user.Password == request.Password)
                {
                    var token = _tokenService.CreateToken(user);                   
                    var result = new LoginResultViewModel
                    {
                        Token = token
                    };
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Wrong email or password");
                }
            }
            else
            {
                return BadRequest("Wrong email or password");
            }
        }

        [Authorize]
        [HttpGet("Tests")]
        public IActionResult GetTestByUserId()
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "id").Value);
            var result = _context.Tests.Where(x => x.UserId == userId).Select(x=>new TestShortViewModel {
            Id=x.Id,
            Name=x.Name,
            Description=x.TestDescription
            }).ToList();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Questions")]
        public IActionResult GetQuestionByTestId ( int id)
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "id").Value);
            var questions = _context.Questions.Where(x => x.TestId == id && x.Test.UserId ==userId).ToList();
            if (questions.Count > 0)
            {
                var result = questions.Select(x => new QuestionViewModel
                {
                    Id = x.Id,
                    QuestionText = x.QuestionText,
                    Answers = x.Answers.Select(y => new AnswerViewModel
                    {
                        Id = y.Id,
                        Text = y.Text
                    }).ToList()
                }).ToList();               
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("Result")]
        public IActionResult GetResult(List<int> request)
        {
            int indx = 0;
            var answers = _context.Answers;
            foreach(var answer in request)
            {
                if (answers.FirstOrDefault(x => x.Id == answer).IsCorrect)
                {
                    indx++;
                }
            }
            return Ok(new TestResultViewModel
            {
                Mark = indx,
                MaxMark=request.Count
            });
        }
    }


    
}
