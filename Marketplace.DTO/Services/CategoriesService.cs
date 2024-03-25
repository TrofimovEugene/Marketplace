using Marketplace.DTO.DTO.Category;
using Marketplace.DTO.DTO.GlobalCategory;
using Marketplace.DTO.DTO.Subcategory;
using Marketplace.DTO.Repositories.Category;
using Marketplace.DTO.Repositories.GlobalCategory;
using Marketplace.DTO.Repositories.Subcategory;

namespace Marketplace.DTO.Services
{
	public class CategoriesService : ICategoriesService
	{
		private readonly IGlobalCategoryRepository _globalCategoryService;
		private readonly ICategoriesRepository _categoriesService;
		private readonly ISubcategoryRepository _subcategoryService;

		public CategoriesService(
			IGlobalCategoryRepository globalCategoryService,
			ICategoriesRepository categoriesService, 
			ISubcategoryRepository subcategoryService)
		{
			_globalCategoryService = globalCategoryService;
			_categoriesService = categoriesService;
			_subcategoryService = subcategoryService;
		}

		public bool CreateCategory(CategoryDTO categoryDTO)
		{
			if (_globalCategoryService.CheckExistsGlobalCategory(categoryDTO.GlobalCategoryId))
				return _categoriesService.CreateCategory(categoryDTO);
			else
				throw new Exception($"Ошибка! Глобальной категории с таким id={categoryDTO.GlobalCategoryId} не существует.");
		}

		public bool CreateSubcategory(SubcategoryDTO subcategoryDTO)
		{
			if (_categoriesService.CheckExistsCategory(subcategoryDTO.CategoryId))
				return _subcategoryService.CreateSubategory(subcategoryDTO);
			else
				throw new Exception($"Ошибка! Категории с таким id={subcategoryDTO.CategoryId} не существует.");
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
			if (_categoriesService.CheckExistsCategory(categoryUpdateDTO.CategoryId)
				&& _globalCategoryService.CheckExistsGlobalCategory(categoryUpdateDTO.GlobalCategoryId))
				return _categoriesService.UpdateCategory(categoryUpdateDTO);
			else
				throw new Exception($"Категории с таким id={categoryUpdateDTO.CategoryId} не существует или не существует глобальной категории с таким id={categoryUpdateDTO.GlobalCategoryId}");
		}

		public bool UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO)
		{
			if (_subcategoryService.CheckExistsSubcategory(subcategoryUpdateDTO.SubcategoryId)
				&& _categoriesService.CheckExistsCategory(subcategoryUpdateDTO.CategoryId))
				return _subcategoryService.UpdateSubcategory(subcategoryUpdateDTO);
			else
				throw new Exception($"Подкатегории с таким id={subcategoryUpdateDTO.CategoryId} не существует или не существует категории с таким id={subcategoryUpdateDTO.CategoryId}");
		}
	}
}
