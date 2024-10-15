using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
    * Service classes are used here to implement additional business logic/validation
    * */
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        /*
        Use constructor Injection to inject all required dependencies.
            */
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            return _categoryRepository.CreateCategory(category);
        }

        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                throw new CategoryNotFoundException($"Category with id {categoryId} not found");
            }
            return _categoryRepository.DeleteCategory(categoryId);
        }

        /*
	     * This method should be used to get all category by userId.
	     */
        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            return _categoryRepository.GetAllCategoriesByUserId(userId);
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                throw new CategoryNotFoundException($"Category with id {categoryId} not found");
            }
            return category;
        }

        /*
	    * This method should be used to update a existing category.
	    */
        public bool UpdateCategory(int categoryId, Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }
    }
}
