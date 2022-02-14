using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestService.DataBase.Entites
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Test")]
        public int TestId { get; set; }
        public string QuestionText { get; set; }

        public virtual Test Test { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}
