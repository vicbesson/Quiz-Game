using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITEC275Final_VictorBesson.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        public int? QuizID { get; set; }
        public virtual Quiz Quiz { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        [MaxLength(255), MinLength(1)]
        public string QuestionText { get; set; }
        
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
        public virtual ICollection<LiveQuestion> LiveQuestions { get; set; }
    }
}
