using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineCVAPI.Models
{
    public class CVTemplate
    {
        public CVTemplate()
        {
            CVs = new HashSet<CV>();
        }
        [Key]
        public int Id { get; set; }
        public string templateName { get; set; }
        public string templateHtmlFile { get; set; }
        public string templateImageFile { get; set; }

        public ICollection<CV> CVs { get; set; }
    }
}