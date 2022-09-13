using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PetStore.Controllers;
using PetStore.Models;
using PetStore.Tests.FakeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Tests.Controllers
{
    [TestClass]
    public class AnimalControllerTest
    {
        private IWebHostEnvironment webHostEnvoirment;

        [TestMethod]
        public void HomePageShouldReturnTwoAnimals()
        {
            //Arrange
            var animalRepository = new FakeAnimalRepository();
            var categoryRepository = new FakeCategoryRepository();
            var commentRepository = new FakeCommentRepository();
            var userRepository = new FakeUserRepository();
            var animalController = new AnimalsController(animalRepository, categoryRepository, commentRepository, webHostEnvoirment);
            //Act
            var result = animalController.HomePage() as ViewResult;

            //Assert 
            Assert.AreEqual(typeof(List<Animal>), result!.Model!.GetType());

        }
        [TestMethod]
        public void CataloguePageShouldReturnCategories()
        {
            //Arrange
            var animalRepository = new FakeAnimalRepository();
            var categoryRepository = new FakeCategoryRepository();
            var commentRepository = new FakeCommentRepository();
            var userRepository = new FakeUserRepository();
            var animalController = new AnimalsController(animalRepository, categoryRepository, commentRepository, webHostEnvoirment);
            //Act
            var result = animalController.Catalogue(1) as ViewResult;

            //Assert 
            Assert.AreEqual(typeof(List<Category>), result!.Model!.GetType());
        }
        [TestMethod]
        public void IndexPageShouldReturnAnimals()
        {
            //Arrange
            var animalRepository = new FakeAnimalRepository();
            var categoryRepository = new FakeCategoryRepository();
            var commentRepository = new FakeCommentRepository();
            var userRepository = new FakeUserRepository();
            var animalController = new AnimalsController(animalRepository, categoryRepository, commentRepository, webHostEnvoirment);
            //Act
            var result = animalController.Index() as ViewResult;

            //Assert 
            Assert.AreEqual(typeof(List<Animal>), result!.Model!.GetType());
        }
        [TestMethod]
        public void EditPageShouldReturnAnimals()
        {
            //Arrange
            var animalRepository = new FakeAnimalRepository();
            var categoryRepository = new FakeCategoryRepository();
            var commentRepository = new FakeCommentRepository();
            var userRepository = new FakeUserRepository();
            var animalController = new AnimalsController(animalRepository, categoryRepository, commentRepository, webHostEnvoirment);
            //Act
            var result = animalController.Edit(1) as ViewResult;

            //Assert 
            Assert.AreEqual(typeof(Animal), result!.Model!.GetType());
        }
    }
}
