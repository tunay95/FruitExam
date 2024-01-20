using FruitExamTry.DAL;
using FruitExamTry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FruitExamTry.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _dbContext;

		public HomeController(AppDbContext dbContext)
        {
			_dbContext = dbContext;
		}
        public async Task<IActionResult> Index()
		{
			List<Fruit> fruits = await _dbContext.Fruits.ToListAsync();
			return View(fruits);
		}

	}
}