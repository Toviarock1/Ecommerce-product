﻿using Ecommerce.Infrastructure.Data.DTO;
using Ecommerce.Infrastructure.Services.Implementation;
using Ecommerce.Infrastructure.Services.Interface;
using EcommerceMVC.Data;
using EcommerceMVC.Services.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[AutoValidateAntiforgeryToken]
	public class ProductController : Controller
	{
		private readonly EcommerceDbContext _context;
		private readonly ICategoryRepository _categoryRepository;

		public ProductController(EcommerceDbContext context, ICategoryRepository categoryRepository)
		{
			_context = context;
			_categoryRepository = categoryRepository;
		}

		public async Task<IActionResult> Index()
		{
			//IEnumerable<Category> productProperty = await _categoryRepository.GetAllCategoriesAsync();
			//return View(productProperty);
			return View();
		}

		public async Task<IActionResult> Upsert(long id)
		{
			// Drop down for Category
			ProductDTO productDTO = new()
			{
				Product = new(),
				CategoryList = (await _categoryRepository.GetAllCategoriesAsync()).Select(x => new SelectListItem
				{
					Text = x.Name,
					Value = x.Id.ToString()
				}),
			};

			if (id is not 0)
			{
				// Update product
				
				return View(product);

			}
			// Create product
			ViewBag.CategoryList = CategoryList;
			return View(product);
		}

		//[HttpPost]
		//public IActionResult Edit(Category productProperty)
		//{
		//	if (productProperty.Name == productProperty.DisplayOrder.ToString())
		//	{
		//		ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
		//	}
		//	if (ModelState.IsValid)
		//	{
		//		_categoryRepository.Update(productProperty);
		//		TempData["Success"] = "Category updated successfully";
		//		return RedirectToAction("Index");
		//	}
		//	return View(productProperty);
		//}

		//public async Task<IActionResult> Delete(long id)
		//{
		//	Category category = await _categoryRepository.GetIdAsync(id);

		//	if (category == null)
		//	{
		//		return NotFound();
		//	}
		//	return View(category);
		//}
		//[HttpPost]
		//public async Task<IActionResult> DeletePOST(long id)
		//{
		//	Category productProperty = await _categoryRepository.GetIdAsync(id);
		//	if (productProperty == null)
		//	{
		//		return NotFound();
		//	}
		//	_categoryRepository.Delete(productProperty);
		//	TempData["Success"] = "Category deleted successfully";
		//	return RedirectToAction("Index");
		//}


	}

}

