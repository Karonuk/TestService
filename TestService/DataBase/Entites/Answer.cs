using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestService.DataBase.Entites
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }
    }
}
