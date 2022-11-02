using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Review_Site_Spectaculars.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        /*[Display(Name = "Reviewers")]*/
        public string? ReviewerName { get; set; }    
        public string? Content { get; set; }
        public int? ProductId { get; set; }
        public virtual ProductModels? Product { get; set; }
    }
}
