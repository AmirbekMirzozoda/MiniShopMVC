using Microsoft.AspNetCore.Mvc;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Filters;
using MiniShopMVC.Models.ViewModels;
using MiniShopMVC.Services;

namespace MiniShopMVC.Controllers;

public class CategoryController(ICategoryService service): Controller
{
    public async Task<IActionResult> Index()
    {
        var categories = await service.GetCategoriesAsync(new CategoryFilter());
        return View(categories);
    }
    
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CategoryAddViewModel model)
    {
        var category = await service.AddCategoryAsync(model);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Update([FromQuery] CategoryUpdateViewModel model)
    {
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateAsync([FromForm] CategoryUpdateViewModel model)
    {
        await service.UpdateCategoryAsync(model);
        return RedirectToAction("Index");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await service.DeleteCategoryAsync(id);
        return RedirectToAction("Index");
    }
}