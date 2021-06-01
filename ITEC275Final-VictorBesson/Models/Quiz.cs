using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITEC275Final_VictorBesson.Models
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizID { get; set; }
        [MaxLength(60), MinLength(1)]
        [Required]
        public string Title { get; set; }
        [Required]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool IsPrivate { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<LiveGame> LiveGames { get; set; }
        public virtual ICollection<SharedQuiz> SharedQuizzes { get; set; }
    }
}
