using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITEC275Final_VictorBesson.Models
{
    public class LiveAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LiveAnswerID { get; set; }
        [Required]
        public int AnonUserID { get; set; }
        public virtual AnonUser AnonUser {get;set;}
        [Required]
        public int LiveQuestionID { get; set; }
        public virtual LiveQuestion LiveQuestion { get; set; }
        [Required]
        public int QuestionAnswerID { get; set; }
        public QuestionAnswer QuestionAnswer { get; set; }
        public DateTime? AnswerDate { get; set; }
    }
}
