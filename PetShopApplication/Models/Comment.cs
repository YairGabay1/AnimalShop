using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApplication.Models
{
    public class Comment
    {
        public int? Id { get; set; }
        public int? AnimalId { get; set; }
        [ForeignKey("AnimalId")]
        public Animal? Animal { get; set; }
        public string? CommentMassage  { get; set; }
    }
}
