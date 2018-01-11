using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCVAPI.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string jobTitle { get; set; }
        public string Employer { get; set; }
        public string Location { get; set; }
        public string startMonth { get; set; }
        public string startYear { get; set; }
        public string endMonth { get; set; }
        public string endYear { get; set; }
        public int stillInRole { get; set; }
        public int CVId {get; set;}
        
        [ForeignKey("CVId")]
        public CV cv { get; set; }
    }
}