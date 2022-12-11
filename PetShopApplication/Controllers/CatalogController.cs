using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;
using PetShopApplication.Reposotories;

namespace PetShopApplication.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRepository _repository;
        public CatalogController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult CatalogPage(int id =1)
        {
            ViewBag.currentCategory = _repository.CurrentCategory(id).Name;
            ViewBag.Category = _repository.GetAllCategory();
            return View(_repository.GetAnimalByCategoryId(id));
        }

        public IActionResult DetailPage(int id)
        {
            var animal = _repository.GetAnimals().First(an => an.AnimalId == id);
            DetailViewModel model = new()
            {
                Animal = animal,
                AnimalCategory = (_repository.CurrentCategory(animal.CategoryId) as Category).Name!,
                AnimalComments = animal.Comments!
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult DetailPage(int Animal, string CommentMessage)
        {
            var animal = _repository.GetAnimals().First(an => an.AnimalId == Animal);
            animal.Comments!.Add(new Comment() { CommentMassage = CommentMessage });
            _repository.SaveComment();
            return RedirectToAction("CatalogPage");
        }
    }
}

