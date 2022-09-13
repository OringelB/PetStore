using PetStore.Models;

namespace PetStore.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetTopTwoAnimals();
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimalById(int animalId);
        void DeleteAnimal(Animal animal);
        void EditAnimal(Animal animal);
        void CreateAnimal(Animal animal);
    }
}
