using System.ComponentModel.DataAnnotations;

namespace withEF.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Publication date")]
        public DateTime PublishDate { get; set; }

        public string Content {set; get;}
    }
}