using Marketplace.DTO.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.DTO.Services.Category
{
	public interface ICategoriesService
	{
		public bool CreateCategory(CategoryDTO categoryDTO);

		public bool UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);

		public List<CategoryDTO> GetCategories(int globalCategoryId);

		public List<CategoriesWithSubcategoriesDTO> GetCategoriesWithSubcategory(int globalCategoryId);
	}
}
