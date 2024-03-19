using Marketplace.DTO.DTO.Category;
using Marketplace.DTO.DTO.GlobalCategory;
using Marketplace.DTO.DTO.Subcategory;
using Marketplace.DTO.Services.Category;
using Marketplace.DTO.Services.GlobalCategory;
using Marketplace.DTO.Services.Subcategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.DTO.Repositories
{
	public class CategoriesRepository : ICategoriesRepository
	{
		private readonly IGlobalCategoryService _globalCategoryService;
		private readonly ICategoriesService _categoriesService;
		private readonly ISubcategoryService _subcategoryService;

		public CategoriesRepository(
			IGlobalCategoryService globalCategoryService, 
			ICategoriesService categoriesService, 
			ISubcategoryService subcategoryService)
		{
			_globalCategoryService = globalCategoryService;
			_categoriesService = categoriesService;
			_subcategoryService = subcategoryService;
		}

		public bool CreateCategory(CategoryDTO categoryDTO)
		{
			return _categoriesService.CreateCategory(categoryDTO);
		}

		public bool CreateSubcategory(SubcategoryDTO subcategoryDTO)
		{
			return _subcategoryService.CreateSubategory(subcategoryDTO);
		}

		public List<CategoryDTO> GetCategories(int globalCategoryId)
		{
			return _categoriesService.GetCategories(globalCategoryId);
		}

		public List<CategoriesWithSubcategoriesDTO> GetCategoriesWithSubcategories(int globalCategoryId)
		{
			return _categoriesService.GetCategoriesWithSubcategory(globalCategoryId);
		}

		public List<GlobalCategoryDTO> GetGlobalCategories()
		{
			return _globalCategoryService.GetGlobalCategories();
		}

		public List<GlobalCategoriesWithCategoriesDTO> GetGlobalCategoriesWithCategories()
		{
			return _globalCategoryService.GetGlobalCategoriesWithCategories();
		}

		public List<SubcategoryDTO> GetSubcategories(int category)
		{
			return _subcategoryService.GetSubcategories(category);
		}

		public bool UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
		{
			return _categoriesService.UpdateCategory(categoryUpdateDTO);
		}

		public bool UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO)
		{
			return _subcategoryService.UpdateSubcategory(subcategoryUpdateDTO);
		}
	}
}
