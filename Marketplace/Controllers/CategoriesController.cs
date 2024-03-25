using Marketplace.DTO.DTO.Category;
using Marketplace.DTO.DTO.GlobalCategory;
using Marketplace.DTO.DTO.Subcategory;
using Marketplace.DTO.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private ICategoriesService _categoriesRepository;
		public CategoriesController(ICategoriesService categoriesRepository) 
		{
			_categoriesRepository = categoriesRepository;
		}

		[HttpPost]
		[Route("CreateCategory")]
		public IActionResult CreateCategory(CategoryDTO category)
		{
			if (_categoriesRepository.CreateCategory(category))
				return Ok();
			else
				return BadRequest();
		}

		[HttpPost]
		[Route("CreateSubcategory")]
		public IActionResult CreateSubcategory(SubcategoryDTO subcategory)
		{
			if (_categoriesRepository.CreateSubcategory(subcategory))
				return Ok();
			else
				return BadRequest();
		}

		[HttpPut]
		[Route("UpdateCategory")]
		public IActionResult UpdateCategory(CategoryUpdateDTO category)
		{
			if (_categoriesRepository.UpdateCategory(category)) 
				return Ok();
			else
				return BadRequest();
		}

		[HttpPut]
		[Route("UpdateSubcategory")]
		public IActionResult UpdateSubcategory(SubcategoryUpdateDTO subcategory)
		{
			if (_categoriesRepository.UpdateSubcategory(subcategory))
				return Ok();
			else
				return BadRequest();
		}

		[HttpGet]
		[Route("GetCategories/{id}")]
		public List<CategoriesWithSubcategoriesDTO> GetCategories(int id)
		{
			return _categoriesRepository.GetCategoriesWithSubcategories(id);
		}

		[HttpGet]
		[Route("GetSubcategories/{id}")]
		public List<SubcategoryDTO> GetSubcategories(int id)
		{
			return _categoriesRepository.GetSubcategories(id);
		}

		[HttpGet]
		[Route("GetGlobalCategories")]
		public List<GlobalCategoryDTO> GetGlobalCategories()
		{
			return _categoriesRepository.GetGlobalCategories();
		}

		[HttpGet]
		[Route("GetGlobalCategoriesWithCategories")]
		public List<GlobalCategoriesWithCategoriesDTO> GetGlobalCategoriesWithCategories()
		{
			return _categoriesRepository.GetGlobalCategoriesWithCategories();
		}
	}
}
