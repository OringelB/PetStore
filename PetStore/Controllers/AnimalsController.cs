using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Models;
using PetStore.Repositories;

namespace PetStore.Controllers
{
    public class AnimalsController : Controller
    {

        //Repositories
        IAnimalRepository _animalRepository;
        ICategoryRepository _categoryRepository;
        ICommentRepository _commentRepository;
        IWebHostEnvironment _webHostEnvironment;
  

        public AnimalsController(IAnimalRepository animalRepository,
            ICategoryRepository categoryRepository, ICommentRepository commentRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _animalRepository = animalRepository;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //Home Page of the website
        public IActionResult HomePage()
        {
            ViewBag.UserRank = CurrentUser.Instance.UserRank;
            return View(_animalRepository.GetTopTwoAnimals());
        }

        //Catalogue page
        public IActionResult Catalogue(int id)
        {
            ViewBag.UserRank = CurrentUser.Instance.UserRank;
            ViewBag.categoryById = _categoryRepository.GetCategoriesById(id);
            return View(_categoryRepository.GetCategories());
        }

        //Animal details page
        public IActionResult AnimalDetails(int id)
        {
            ViewBag.UserRank = CurrentUser.Instance.UserRank;
            ViewBag.animalById = _animalRepository.GetAnimalById(id);
            return View();
        }

        //Add a comment to animal details
        [HttpPost]
        public IActionResult AnimalDetails(Comment comment)
        {

            _commentRepository.AddNewComment(comment);
            return RedirectToAction("AnimalDetails", comment.AnimalId);
        }

        // GET: Animals
        public IActionResult Index()
        {
            ViewBag.UserRank = CurrentUser.Instance.UserRank;
            var animals = _animalRepository.GetAnimals();
            return View(animals);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewBag.UserRank = CurrentUser.Instance.UserRank;

            var categories = _categoryRepository.GetCategories();
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Animals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Animal animal)
        {
            if(animal.Photo != null)
            {
                string folder = "Pictures/";
                folder += animal.Photo.FileName;
                animal.Picture ="/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                animal.Photo.CopyTo(new FileStream(serverFolder,FileMode.Create));
            }
            _animalRepository.CreateAnimal(animal);
            return RedirectToAction(nameof(Index));
        }

        // GET: Animals/Edit
        public IActionResult Edit(int id)
        {
            ViewBag.UserRank = CurrentUser.Instance.UserRank;
            if (id == null )
            {
                return NotFound();
            }

            ViewBag.animalId = id;
            var animal =  _animalRepository.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }
            var categories = _categoryRepository.GetCategories();
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName", animal.CategoryId);

            return View(animal);
        }

        // POST: Animals/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Animal animal)
        {
            _animalRepository.EditAnimal(animal);
            return RedirectToAction(nameof(Index));
        }

        // GET: Animals/Delete/5
        public IActionResult Delete(int id)
        {
            ViewBag.UserRank = CurrentUser.Instance.UserRank;
            var animal = _animalRepository.GetAnimalById(id);
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var animal = _animalRepository.GetAnimalById(id);
            _animalRepository.DeleteAnimal(animal);
            return RedirectToAction(nameof(Index));
        }
    }
}
