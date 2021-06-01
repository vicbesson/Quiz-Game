using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITEC275Final_VictorBesson.Models
{
    public class LiveQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LiveQuestionID { get; set; }
        [Required]
        public int LiveGameID { get; set; }
        public virtual LiveGame LiveGame { get; set; }
        [Required]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
        public DateTime? EndDateTime { get; set; }

        public virtual ICollection<LiveAnswer> LiveAnswers { get; set; }
    }
}
