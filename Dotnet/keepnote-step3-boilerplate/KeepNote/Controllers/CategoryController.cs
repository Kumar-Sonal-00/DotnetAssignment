﻿using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace KeepNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*
 * As in this assignment, we are working with creating RESTful web service, hence annotate
 * the class with [ApiController] annotation and define the controller level route as per REST Api standard.
 */

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        /*
      * CategoryService should  be injected through constructor injection. Please note that we should not create service
      * object using the new keyword
      */

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            var createdCategory = _categoryService.CreateCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryId }, createdCategory);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category is null.");
            }

            var result = _categoryService.UpdateCategory(id, category);
            if (!result)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound($"Category with id {id} not found");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound($"Category with id {id} not found");
        }
        [HttpGet("user/{userId}")]
        public IActionResult GetAllCategoriesByUserId(string userId)
        {
            var categories = _categoryService.GetAllCategoriesByUserId(userId);
            return Ok(categories);
        }

        /*
         * Define a handler method which will create a category by reading the
         * Serialized category object from request body and save the category in
         * category table in database. Please note that the careatorId has to be unique
         * and the userID should be taken as the categoryCreatedBy for the
         * category. This handler method should return any one of the status messages
         * basis on different situations: 1. 201(CREATED - In case of successful
         * creation of the category 2. 409(CONFLICT) - In case of duplicate categoryId
         * 
         *  * This handler method should map to the URL "/api/category" using HTTP POST method
        /*
         
          
         * Define a handler method which will delete a category from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the category deleted successfully from
         * database. 2. 404(NOT FOUND) - If the category with specified categoryId is
         * not found. 
         * 
         * This handler method should map to the URL "/api/category/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid categoryId without {}
         */

        /*
         * Define a handler method which will update a specific category by reading the
         * Serialized object from request body and save the updated category details in
         * a category table in database handle CategoryNotFoundException as well. please
         * note that the loggedIn userID should be taken as the categoryCreatedBy for
         * the category. This handler method should return any one of the status
         * messages basis on different situations: 1. 200(OK) - If the category updated
         * successfully. 2. 404(NOT FOUND) - If the category with specified categoryId
         * is not found. 
         * 
         * This handler method should map to the URL "/api/category/{id}" using HTTP PUT
         * method.
         */

        /*
         * Define a handler method which will get us the category by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the category found successfully. 
         * 
         * This handler method should map to the URL "/api/category/{userId}" using HTTP GET method
         */
    }
}
