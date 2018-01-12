using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCVAPI.Models
{
    public class Experience : TEntity
    {
        [StringLength(50)]
        public string jobTitle { get; set; }

        [StringLength(50)]
        public string Employer { get; set; }
        
        [StringLength(50)]
        public string Location { get; set; }
        
        [StringLength(4)]
        public string startMonth { get; set; }
        
        [StringLength(4)]
        public string startYear { get; set; }

        [StringLength(4)]
        public string endMonth { get; set; }
        
        [StringLength(4)]
        public string endYear { get; set; }
        public bool stillInRole { get; set; }
        public int CVId {get; set;}
        
        [ForeignKey("CVId")]
        public CV cv { get; set; }
    }
}