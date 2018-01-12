using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineCVAPI.Models
{
    public class CVTemplate : TEntity
    {
        public CVTemplate()
        {
            CVs = new HashSet<CV>();
        }

        [StringLength(50)]
        public string templateName { get; set; }
        
        [StringLength(50)]
        public string templateHtmlFile { get; set; }
        
        [StringLength(50)]
        public string templateImageFile { get; set; }

        public ICollection<CV> CVs { get; set; }
    }
}