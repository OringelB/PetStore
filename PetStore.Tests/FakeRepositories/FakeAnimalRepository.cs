using PetStore.Models;
using PetStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Tests.FakeRepositories
{
    public class FakeAnimalRepository : IAnimalRepository
    {
        private IEnumerable<Animal> _animals;
        public FakeAnimalRepository()
        {
            _animals = new List<Animal>() { new Animal(), new Animal() };
        }
        public void CreateAnimal(Animal animal)
        {
        }

        public void DeleteAnimal(Animal animal)
        {
        }

        public void EditAnimal(Animal animal)
        {
        }

        public Animal GetAnimalById(int animalId)
        {
            return new Animal();
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _animals;
        }

        public IEnumerable<Animal> GetTopTwoAnimals()
        {
            return _animals;
        }
    }
}
