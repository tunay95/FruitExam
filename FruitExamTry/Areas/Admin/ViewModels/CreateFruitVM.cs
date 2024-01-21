namespace FruitExamTry.Areas.Admin.ViewModels
{
    public class CreateFruitVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }

        public IFormFile? Image { get; set; }
    }
}
