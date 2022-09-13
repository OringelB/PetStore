using Microsoft.EntityFrameworkCore;
using PetStore.Data;
using PetStore.Models;

namespace PetStore.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private PetContext _context;
        

        public AnimalRepository(PetContext context)
        {
            _context = context;

        }

        public void CreateAnimal(Animal animal)
        {
            _context.Add(animal);
            _context.SaveChanges();
        }

        public void DeleteAnimal(Animal animal)
        {
            _context.Animals!.Remove(animal);
            _context.SaveChangesAsync();
        }

        public void EditAnimal(Animal animal)
        {
          _context.Update(animal);
            _context.SaveChanges();
        }

        public Animal GetAnimalById(int animalId)
        {
            var animalById = _context!.Animals!
                .Include(animal => animal.Comments)
                .First(animal => animal.AnimalId == animalId);
            return animalById;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals!.Include(a => a.Category);
        }

        public IEnumerable<Animal> GetTopTwoAnimals()
        {
            var animals = _context.Animals!
                         .Include(animal => animal.Comments)
                         .OrderByDescending(animal => animal.Comments!.Count)
                         .Take(2);
            return animals;
        }
    }
}
