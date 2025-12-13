using Microsoft.AspNetCore.Mvc;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;
using MiniShopMVC.Models.Filters;
using MiniShopMVC.Models.ViewModels;
using MiniShopMVC.Services;

namespace MiniShopMVC.Controllers;

public class CategoryController(ICategoryService service): Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Categories = await service.GetCategoriesAsync(new CategoryFilter());
        return View();
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
    public IActionResult Update([FromQuery] CategoryUpdateViewModel model)
    {
        ViewBag.Category = model;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Update([FromForm] Category model)
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