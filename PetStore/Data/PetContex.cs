using Microsoft.EntityFrameworkCore;
using PetStore.Models;

namespace PetStore.Data
{
    public class PetContext : DbContext
    {
        //public void AddCascadingObject(object rootEntity) //Place inside DbContext.cs
        //{
        //    ChangeTracker.TrackGraph(
        //        rootEntity,
        //        node =>
        //            node.Entry.State = !node.Entry.IsKeySet ? EntityState.Added : EntityState.Unchanged
        //    );
        //}
        //wwwroot
        //png

        //Animals, Comments and categories for the data base
        Animal Pidgeon = new Animal { AnimalId = 1, Name = "Pidgeon", Age = 1, Picture = "/Pictures/Pidgeon.png", Description = "A cute pidgeon", CategoryId = 2 };
        Animal Dog = new Animal { AnimalId = 2, Name = "Dog", Age = 2, Picture = "/Pictures/Dog.Jpg", Description = "A cute dog", CategoryId = 1 };
        Animal Pig = new Animal { AnimalId = 3, Name = "Pig", Age = 3, Picture = "/Pictures/Pig.Jpg", Description = "A cute pig", CategoryId = 1 };
        Animal Cat = new Animal { AnimalId = 4, Name = "Cat", Age = 4, Picture = "/Pictures/Cat.Png", Description = "A cute cat", CategoryId = 1 };

        Comment comment1 = new Comment { CommentId = 1, CommentData = "Best cat ever!", AnimalId = 4 };
        Comment comment2 = new Comment { CommentId = 2, CommentData = "Fattest cat ever!", AnimalId = 4 };
        Comment comment3 = new Comment { CommentId = 3, CommentData = "I Just love this dog!", AnimalId = 2 };
        Comment comment4 = new Comment { CommentId = 4, CommentData = "This cat likes to sleep!", AnimalId = 4 };

        Category Mamels = new Category { CategoryId = 1, CategoryName = "Mamels" };
        Category Birds = new Category { CategoryId = 2, CategoryName = "Birds" };

        User user = new User { UserId = 1, UserName = "Ori", Password = "1234", UserRank = 2 };
        User user2 = new User { UserId = 2, UserName = "Dean", Password = "1234", UserRank = 1 };

        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<User>? Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                comment1,
                comment2,
                comment3,
                comment4

            );
            modelBuilder.Entity<Category>().HasData(
                Mamels,
                Birds
        );
            modelBuilder.Entity<Animal>().HasData(
                Pidgeon,
                Dog,
                Pig,
                Cat
        );
            modelBuilder.Entity<User>().HasData(
                user,
                user2
                );
   
        }


    }



}
