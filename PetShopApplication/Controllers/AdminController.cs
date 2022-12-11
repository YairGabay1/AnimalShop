using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;
using PetShopApplication.Reposotories;

namespace PetShopApplication.Controllers
{
	public class AdminController : Controller
    {
        private readonly IRepository _repository;
        public AdminController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult AdminPage(int id = 1)
        {
            return View(_repository.GetAnimals().Where(anm => anm.CategoryId == id));
        }
        public IActionResult DeleteAnimal(int id)
        {
            _repository.DeleteAnimal(id);
            return RedirectToAction("AdminPage");
        }
        [HttpGet]
        public IActionResult EditAnimal(int id)
        {
            var currentAnimal = _repository.GetAnimals().FirstOrDefault(an => an.AnimalId == id);
            return View(currentAnimal);
        }
        [HttpPost]
        public IActionResult EditAnimal(int id, Animal animal)
        {
            _repository.UpdateAnimal(id, animal, animal.ImageUrl!);
            return RedirectToAction("AdminPage");
        }
        [HttpGet]
        public IActionResult AddAnimal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            _repository.InsertAnimal(animal, animal.ImageUrl!);
            return RedirectToAction("AdminPage");
        }
    }
}
