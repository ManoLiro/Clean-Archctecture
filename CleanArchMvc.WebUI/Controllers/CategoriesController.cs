using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryservice)
        {
            _categoryService = categoryservice;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategory();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var category = await _categoryService.GetById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CategoryDTO category)
        {

            if (ModelState.IsValid)
            {
                await _categoryService.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            return View(category);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id,string a)
        {

            await _categoryService.Remove(id);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var category = await _categoryService.GetById(id);
            if(category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        



    }
}
