using Microsoft.EntityFrameworkCore;
using PetShopApplication.Models;

namespace PetShopApplication.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Comment>? Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Mamal" },
                new { CategoryId = 2, Name = "Reptile" },
                new { CategoryId = 3, Name = "Aquatic" }
            );
            modelBuilder.Entity<Animal>().HasData(
				new { AnimalId = 1, Name = "Dog", Age = 3, ImageUrl = "https://i.natgeofe.com/n/5f35194b-af37-4f45-a14d-60925b280986/NationalGeographic_2731043_4x3.jpg", Description = "The dog is a very comfortable animal to raise indoors, the dog gets along well with children and is very loyal to its owner.", CategoryId = 1 },
				new { AnimalId = 2, Name = "Cat", Age = 5, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Cat_November_2010-1a.jpg/1200px-Cat_November_2010-1a.jpg", Description = "The domestic cat is a domesticated carnivorous mammal, of the cat family. The cat is common on all continents of the world except Antarctica. It is speculated that it originated from the wild cat. The cat is a nocturnal predator of rodents, birds and fish", CategoryId = 1 },
				new { AnimalId = 3, Name = "Monkey", Age = 2, ImageUrl = "https://images.unsplash.com/flagged/photo-1566127992631-137a642a90f4?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&w=1000&q=80", Description = "Monkeys are among the most curious and intelligent animals, considered very intelligent", CategoryId = 1 },
                new { AnimalId = 4, Name = "Shark",Age = 7, ImageUrl = "https://media.istockphoto.com/photos/great-white-shark-smile-picture-id533130811?k=20&m=533130811&s=612x612&w=0&h=9OoWmY857Nr5Yj6IPDVv-CXn-QxdrZXa46o03XPbJxs=", Description = "Sharks are good swimmers. Many of the shark species are active predators that attack fish and other marine creatures, including marine mammals. Most sharks have very sharp senses with an emphasis on smell and sight.", CategoryId = 3 },
                new { AnimalId = 5, Name = "Gold Fish", Age = 9, ImageUrl = "https://cafishvet.com/wp-content/uploads/2020/10/gold-fish-1.jpg", Description = "The common goldfish is the most common type of fish. Its body structure is slightly different from the natural race: its body is elongated and its fins and tail are relatively short. The fish tends to be red-gold but can also appear in blue, white and black.", CategoryId = 3 },
                new { AnimalId = 6, Name = "Tarantula", Age = 6, ImageUrl = "https://static01.nyt.com/images/2020/10/06/science/24TB-TARANTULA1/24TB-TARANTULA1-mediumSquareAt3X.jpg", Description = "The curly tarantula has a full body covered in hairs that range in color from dark brown to black. The long, golden hairs that cover her entire body give her a golden-bronze sheen. These hairs are especially dense in the area of the hind legs. The color of the males is lighter.", CategoryId = 2 },
                new { AnimalId = 7, Name = "Anaconda", Age = 8, ImageUrl = "https://i.natgeofe.com/k/1fb6fee3-db45-4976-90b0-67a6ad6821a2/anaconda-water_2x1.jpg", Description = "Adult anacondas usually reach an average length of 3-3.7 m. The females are bigger than the males. Their skin is yellow, golden-beige or green-yellow with a series of black or dark brown saddle-shaped spots.", CategoryId = 2 },
                new { AnimalId = 8, Name = "Dolphin", Age = 3, ImageUrl = "https://www.cmaquarium.org/app/uploads/2021/06/2021.04-Nick-Underwater-0001.jpg", Description = "Adult anacondas usually reach an average length of 3-3.7 m. The females are bigger than the males. Their skin is yellow, golden-beige or green-yellow with a series of black or dark brown saddle-shaped spots.", CategoryId = 3 }
				
				
                );
            modelBuilder.Entity<Comment>().HasData(
                new { Id = 1, AnimalId = 1, CommentMassage = "Friendly animal" },
                new { Id = 2, AnimalId = 1, CommentMassage = "Loyal animal" },
                new { Id = 3, AnimalId = 1, CommentMassage = "Kids love him" },
                new { Id = 4, AnimalId = 2, CommentMassage = "Not pooping at home" },
                new { Id = 5, AnimalId = 3, CommentMassage = "Very smart" },
                new { Id = 6, AnimalId = 3, CommentMassage = "Messes up the house" },
                new { Id = 7, AnimalId = 3, CommentMassage = "Beautiful animal" },
                new { Id = 8, AnimalId = 4, CommentMassage = "big and scary" },
                new { Id = 9, AnimalId = 5, CommentMassage = "Easy to grow" },
                new { Id = 10, AnimalId = 5, CommentMassage = "Eat once a day" },
                new { Id = 11, AnimalId = 6, CommentMassage = "Scary" },
                new { Id = 12, AnimalId = 7, CommentMassage = "impressive animal" }
                );
            modelBuilder.Entity<Animal>().HasMany(c => c.Comments).WithOne(an => an.Animal).OnDelete(DeleteBehavior.Cascade);
        }
	}
}