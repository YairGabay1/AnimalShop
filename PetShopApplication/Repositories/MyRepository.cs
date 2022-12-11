using Microsoft.EntityFrameworkCore;
using PetShopApplication.Data;
using PetShopApplication.Models;
using PetShopApplication.Reposotories;

namespace PetShopApplication.Repositories
{
    public class MyRepository : IRepository
    {
        private readonly MyDbContext _mycontext;
        public MyRepository(MyDbContext animalcontext)
        {
            _mycontext = animalcontext;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _mycontext!.Animals!.Include(a => a.Comments);
        }

        public IEnumerable<Animal> GetAnimalByCategoryId(int categoryId)
        {
            return _mycontext!.Animals!.Include(a => a.Comments).Where(c => c.CategoryId == categoryId).ToList();
        }
        public IEnumerable<Category> GetAllCategory()
        {
            return _mycontext.Categories!;
        }
        public Category CurrentCategory(int id)
        {
            return _mycontext.Categories!.First(c => c.CategoryId == id);
        }
        public void SaveComment() => _mycontext.SaveChanges();
        public void DeleteAnimal(int id)
        {
            var animalInDb = _mycontext.Animals!.SingleOrDefault(a => a.AnimalId == id);
            _mycontext.Animals!.Remove(animalInDb!);
            _mycontext.SaveChanges();
        }
        public void UpdateAnimal(int id, Animal animal,string imgUrl)
        {
            var animalInDb = _mycontext.Animals!.SingleOrDefault(a => a.AnimalId == id);
            animalInDb!.Name = animal.Name;
            animalInDb.Age = animal.Age;
            animalInDb.ImageUrl = imgUrl;
            animalInDb.CategoryId = animal.CategoryId;
            animalInDb.Description = animal.Description;
            _mycontext.SaveChanges();
        }
       public void InsertAnimal(Animal animal,string imgUrl)
        {
            animal.ImageUrl = imgUrl ;
            _mycontext.Animals!.Add(animal);
            _mycontext.SaveChanges();
        }

    }
}
