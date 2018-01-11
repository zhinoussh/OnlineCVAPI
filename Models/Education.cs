using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCVAPI.Models
{
    public class Education
    {
        [Key]
        public int ID { get; set; }
        public string institute { get; set; }
        public string graduationYear { get; set; }

        public int CVId { get; set; }   
        [ForeignKey("CVId")]
        public CV cv { get; set; }
    }
}