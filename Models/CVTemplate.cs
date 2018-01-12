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
        public string templateName { get; set; }
        public string templateHtmlFile { get; set; }
        public string templateImageFile { get; set; }

        public ICollection<CV> CVs { get; set; }
    }
}