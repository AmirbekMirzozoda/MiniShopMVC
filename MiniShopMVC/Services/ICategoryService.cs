using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;
using MiniShopMVC.Models.Filters;
using MiniShopMVC.Models.ViewModels;

namespace MiniShopMVC.Services;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync(CategoryFilter f);
    Task<Category> AddCategoryAsync(CategoryAddViewModel model);
    Task UpdateCategoryAsync(CategoryUpdateViewModel model);
    Task DeleteCategoryAsync(int id);
}