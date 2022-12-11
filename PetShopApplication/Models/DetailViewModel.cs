namespace PetShopApplication.Models
{
    public class DetailViewModel
    {
        public Animal? Animal { get; set; }
        public IEnumerable<Comment>? AnimalComments { get; set; }
        public string? AnimalCategory { get; set; }
    }
}
