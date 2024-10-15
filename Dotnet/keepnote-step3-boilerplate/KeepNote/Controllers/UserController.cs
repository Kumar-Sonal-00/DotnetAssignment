using Entities;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /*
         * UserService should  be injected through constructor injection. Please note that we should not create service
         * object using the new keyword
        */
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            var result = _userService.RegisterUser(user);
            if (result)
            {
                return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
            }
            return BadRequest("User already exists");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }

            var result = _userService.UpdateUser(id, user);
            if (!result)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var user = _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User with id {id} not found");
        }

        [HttpPost("validate")]
        public IActionResult ValidateUser([FromBody] UserCredentials credentials)
        {
            var result = _userService.ValidateUser(credentials.UserId, credentials.Password);
            if (result)
            {
                return Ok("User is valid");
            }
            return Unauthorized("Invalid credentials");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var result = _userService.DeleteUser(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound($"User with id {id} not found");
        }

        /*
	     * Define a handler method which will create a specific user by reading the
	     * Serialized object from request body and save the user details in a User table
	     * in the database. This handler method should return any one of the status
	     * messages basis on different situations: 1. 201(CREATED) - If the user created
	     * successfully. 2. 409(CONFLICT) - If the userId conflicts with any existing
	     * user
	     * 
	     * 
	     * This handler method should map to the URL "/api/user/register" using HTTP POST
	     * method
	     */

        /*
         * Define a handler method which will login a specific user by reading the
         * Serialized object from request body and validate the userId and Password
         * from User table in the database. This handler method should return any one of 
         * the status messages basis on different situations: 
         * 1. 200(OK) - If the user successfully logged in. 
         * 2. 404(NOTFOUND) -If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/login" using HTTP POST
         * method
         */

        /*
         * Define a handler method which will update a specific user by reading the
         * Serialized object from request body and save the updated user details in a
         * user table in database handle exception as well. This handler method should
         * return any one of the status messages basis on different situations: 1.
         * 200(OK) - If the user updated successfully. 2. 404(NOT FOUND) - If the user
         * with specified userId is not found. 
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP PUT method.
         */

        /*
         * Define a handler method which will delete a user from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the user deleted successfully from
         * database. 2. 404(NOT FOUND) - If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid userId without {}
         */

        /*
         * Define a handler method which will show details of a specific user handle
         * UserNotFoundException as well. This handler method should return any one of
         * the status messages basis on different situations: 1. 200(OK) - If the user
         * found successfully. 2. 404(NOT FOUND) - If the user with specified
         * userId is not found. This handler method should map to the URL "/api/user/{userId}"
         * using HTTP GET method where "id" should be replaced by a valid userId without
         * {}
         */
    }
    public class UserCredentials
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
