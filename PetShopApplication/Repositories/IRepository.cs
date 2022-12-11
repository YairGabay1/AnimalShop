using PetShopApplication.Models;

namespace PetShopApplication.Reposotories
{
    public interface IRepository
    {
        public IEnumerable<Animal> GetAnimals();
        IEnumerable<Animal> GetAnimalByCategoryId(int categoryId);
        public IEnumerable<Category> GetAllCategory();
        public Category CurrentCategory(int id);
        public void DeleteAnimal(int id);
        public void UpdateAnimal(int id, Animal animal,string imgUrl);
        void SaveComment();
        void InsertAnimal(Animal animal,string imgUrl);
    }
}
