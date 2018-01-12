using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineCVAPI.Models
{
    public class PersonalProfile : TEntity
    {
        public PersonalProfile()
        {
            CVs=new HashSet<CV>();
        }
        [StringLength(50)]
        [Required]
        public string firstName { get; set; }

        [StringLength(50)]
        [Required]
        public string lastName { get; set; }

        [StringLength(10)]
        [Required]
        public string phoneNumber { get; set; }

        [StringLength(50)]
        [Required]
        public string email { get; set; }

        [StringLength(100)]
        public string address { get; set; }
        
        public ICollection<CV> CVs { get; set; }

    }
}