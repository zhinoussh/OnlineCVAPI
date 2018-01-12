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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public ICollection<CV> CVs { get; set; }

    }
}