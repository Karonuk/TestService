using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestService.DataBase.Entites
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string TestDescription { get; set; }
       

        public virtual User User { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
