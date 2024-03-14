using Marketplace.Context.EFCode;
using Marketplace.Context.Models;
using Marketplace.DTO.DTO;
using Marketplace.DTO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly CategoriesService _categoriesService;
		public CategoriesController(CategoriesService categoriesService) 
		{
			_categoriesService = categoriesService;
		}

		[HttpPost]
		[Route("CreateCategory")]
		public IActionResult CreateCategory(CategoryDTO category)
		{
			if (_categoriesService.CreateCategory(category))
				return Ok();
			else
				return BadRequest();
		}

		[HttpPost]
		[Route("CreateSubcategory")]
		public IActionResult CreateSubcategory(SubcategoryDTO subcategory)
		{
			if (_categoriesService.CreateSubategory(subcategory))
				return Ok();
			else
				return BadRequest();
		}

		[HttpGet]
		[Route("GetCategories")]
		public List<CategoriesWithSubcategoriesDTO> GetCategories ()
		{
			return _categoriesService.GetCategoriesWithSubcategory();
		}

		// todo:Доделать выдачу подкатегорий у конкретной категории
		[HttpGet]
		[Route("GetSubcategories")]
		public List<SubcategoryDTO> GetSubcategories()
		{
			return _categoriesService.GetSubcategories();
		}
	}
}
