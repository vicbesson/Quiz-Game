using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITEC275Final_VictorBesson.Models
{
    public class LiveGame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LiveGameID { get; set; }
        [Required]
        public int QuizID { get; set; }
        public virtual Quiz Quiz { get; set; }
        public string RandomCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? EndedDate { get; set; }

        public virtual ICollection<AnonUser> AnonUsers { get; set; }
        public virtual  ICollection<LiveQuestion> LiveQuestions { get; set; }
    }
}
