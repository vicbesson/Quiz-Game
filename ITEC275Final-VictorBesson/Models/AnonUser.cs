using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITEC275Final_VictorBesson.Models
{
    public class AnonUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnonUserID { get; set; }
        [Required]
        public virtual LiveGame LiveGame { get; set; }
        public int LiveGameID { get; set; }
        [MaxLength(15), MinLength(1)]
        [Index(IsUnique = true)]
        [Required]
        public string UserName { get; set; }

        public virtual ICollection<LiveAnswer> LiveAnswers { get; set; }
    }
}
