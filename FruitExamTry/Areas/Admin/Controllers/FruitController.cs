using FruitExamTry.Areas.Admin.ViewModels;
using FruitExamTry.DAL;
using FruitExamTry.Helpers;
using FruitExamTry.Models;
using FruitMVC.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruitExamTry.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class FruitController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public FruitController(AppDbContext dbContext,IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            List<Fruit> fruits = await _dbContext.Fruits.ToListAsync();
            return View(fruits);
        }

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create(CreateFruitVM createFruitVM)
        {
            if(!ModelState.IsValid) return View();

            if (!createFruitVM.Image.CheckContent("Image/"))
            {
                ModelState.AddModelError("Image", " You have to include photo for right format! ");
            }

            if (!createFruitVM.Image.CheckLength(3000000))
            {
                ModelState.AddModelError("Image", " The Size of Photo should be less than 3mb! ");
            }

            Fruit fruit = new Fruit()
            {
                Title=createFruitVM.Title,
                Description=createFruitVM.Description,
                ImgUrl=createFruitVM.ImgUrl,
            };

            await _dbContext.Fruits.AddAsync(fruit);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index),"Fruit");
        
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Update(int id)
        {
            Fruit fruit = await _dbContext.Fruits.Where(f=>f.Id == id).FirstOrDefaultAsync();
            UpdateFruitVM updateFruitVM = new UpdateFruitVM()
            {
                Id = id,
                Title=fruit.Title,
                Description=fruit.Description,
                ImgUrl=fruit.ImgUrl,
            };

            return View(updateFruitVM);

        }

        [HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Update(UpdateFruitVM updateFruitVM)
        {
            if (!ModelState.IsValid) return View();

            Fruit fruit = await _dbContext.Fruits.Where(f=>f.Id==updateFruitVM.Id).FirstOrDefaultAsync();
            if (fruit == null) throw new Exception(" Fruit can't be null! ");

            fruit.Id= updateFruitVM.Id;
            fruit.Title = updateFruitVM.Title;
            fruit.Description = updateFruitVM.Description;
            fruit.ImgUrl = updateFruitVM.Image.Upload(_env.WebRootPath,@"/Upload/"); 

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index),"Home");
        }

		[Authorize(Roles = "Admin")]
		public   IActionResult Delete(int id)
        {
            Fruit fruit = _dbContext.Fruits.Where(f=>f.Id==id).FirstOrDefault();
            _dbContext.Remove(fruit);
            _dbContext.SaveChangesAsync();
            return View();
        }
    }
}
