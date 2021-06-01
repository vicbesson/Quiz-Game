using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC275Final_VictorBesson.Models
{
    public class SharedQuiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SharedQuizID { get; set; }
        [Required]
        public int QuizID { get; set; }
        public virtual Quiz Quiz { get; set; }
        [Required]
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
