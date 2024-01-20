using System.ComponentModel.DataAnnotations.Schema;

namespace FruitExamTry.Models
{
	public class Fruit:BaseEntity
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
