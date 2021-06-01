using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITEC275Final_VictorBesson.Models
{
    public class QuestionAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionAnswerID { get; set; }
        public int? QuestionID { get; set; }
        public virtual Question Question { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        [MaxLength(255), MinLength(1)]
        public string AnswerText { get; set; }
        [Required]
        public bool Answer { get; set; }

        public virtual ICollection<LiveAnswer> LiveAnswers { get; set; }
    }
}
