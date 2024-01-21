namespace FruitExamTry.Areas.Admin.ViewModels
{
    public class UpdateFruitVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        public IFormFile? Image { get; set; }
    }
}
