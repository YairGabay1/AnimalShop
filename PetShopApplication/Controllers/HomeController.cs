using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Repositories;
using PetShopApplication.Reposotories;

namespace PetShopApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAnimals().OrderByDescending(a => a.Comments!.Count).Take(2).ToList());
        }
    }
}
