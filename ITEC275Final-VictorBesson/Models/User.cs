using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITEC275Final_VictorBesson.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [MaxLength(15), MinLength(1)]
        [Index(IsUnique = true)]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<SharedQuiz> SharedQuizzes { get; set; }
    }
}
