using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestService.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string  QuestionText { get; set; }

        public List<AnswerViewModel> Answers { get; set; }
    }
}
