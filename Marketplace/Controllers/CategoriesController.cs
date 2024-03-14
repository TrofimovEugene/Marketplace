using Marketplace.DTO.DTO.Category;
using Marketplace.DTO.DTO.Subcategory;
using Marketplace.DTO.Services;
using Microsoft.AspNetCore.Mvc;

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

		[HttpPut]
		[Route("UpdateCategory")]
		public IActionResult UpdateCategory(CategoryUpdateDTO category)
		{
			if (_categoriesService.UpdateCategory(category)) 
				return Ok();
			else
				return BadRequest();
		}

		[HttpPut]
		[Route("UpdateSubcategory")]
		public IActionResult UpdateSubcategory(SubcategoryUpdateDTO subcategory)
		{
			if (_categoriesService.UpdateSubcategory(subcategory))
				return Ok();
			else
				return BadRequest();
		}

		[HttpGet]
		[Route("GetCategories")]
		public List<CategoriesWithSubcategoriesDTO> GetCategories()
		{
			return _categoriesService.GetCategoriesWithSubcategory();
		}

		[HttpGet]
		[Route("GetSubcategories/{id}")]
		public List<SubcategoryDTO> GetSubcategories(int id)
		{
			return _categoriesService.GetSubcategories(id);
		}
	}
}
