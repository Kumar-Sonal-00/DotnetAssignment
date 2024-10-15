using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class CategoryRepository : ICategoryRepository
    {
        private readonly KeepDbContext _dbContext;
        public CategoryRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }
        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }
        //* This method should be used to get all category by userId.
        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            return _dbContext.Categories.Where(c => c.CategoryCreatedBy == userId).ToList();
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.Find(categoryId);
        }

        /*
	    * This method should be used to update a existing category.
	    */
        public bool UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
