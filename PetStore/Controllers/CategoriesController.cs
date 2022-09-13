using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetStore.Data;
using PetStore.Models;
using PetStore.Repositories;

namespace PetStore.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewBag.UserRank = CurrentUser.Instance.UserRank;
            return View();
        }
        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            _categoryRepository.CreateCategory(category);
            return RedirectToAction("Create", "Animals");
        }
    }
}
