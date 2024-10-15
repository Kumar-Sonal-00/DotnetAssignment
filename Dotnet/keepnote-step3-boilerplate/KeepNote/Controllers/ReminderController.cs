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
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        /*
       * ReminderService should  be injected through constructor injection. Please note that we should not create service
       * object using the new keyword
       */
        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }
        [HttpPost]
        public IActionResult CreateReminder([FromBody] Reminder reminder)
        {
            var createdReminder = _reminderService.CreateReminder(reminder);
            return CreatedAtAction(nameof(GetReminderById), new { id = createdReminder.ReminderId }, createdReminder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReminder(int id, [FromBody] Reminder reminder)
        {
            if (reminder == null)
            {
                return BadRequest("Reminder is null.");
            }

            var result = _reminderService.UpdateReminder(id, reminder);
            if (!result)
            {
                return NotFound($"Reminder with ID {id} not found.");
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReminder(int id)
        {
            var result = _reminderService.DeletReminder(id);
            if (!result)
            {
                return NotFound($"Reminder with ID {id} not found.");
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetReminderById(int id)
        {
            var reminder = _reminderService.GetReminderById(id);
            if (reminder != null)
            {
                return Ok(reminder);
            }
            return NotFound($"Reminder with id {id} not found");
        }
        [HttpGet("user/{userId}")]
        public IActionResult GetAllRemindersByUserId(string userId)
        {
            var reminders = _reminderService.GetAllRemindersByUserId(userId);
            return Ok(reminders);
        }


        /*
	     * Define a handler method which will create a reminder by reading the
	     * Serialized reminder object from request body and save the reminder in
	     * reminder table in database. Please note that the reminderId has to be unique
	     * and userID should be taken as the reminderCreatedBy for the
	     * reminder. This handler method should return any one of the status messages
	     * basis on different situations: 1. 201(CREATED - In case of successful
	     * creation of the reminder 2. 409(CONFLICT) - In case of duplicate reminder ID
	     * 
	     * This handler method should map to the URL "/api/reminder" using HTTP POST
	     * method".
	     */

        /*
         * Define a handler method which will delete a reminder from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the reminder deleted successfully from
         * database. 2. 404(NOT FOUND) - If the reminder with specified reminderId is
         * not found. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid reminderId without {}
         */

        /*
         * Define a handler method which will update a specific reminder by reading the
         * Serialized object from request body and save the updated reminder details in
         * a reminder table in database handle ReminderNotFoundException as well.
         * This handler method should return any one of the status
         * messages basis on different situations: 1. 200(OK) - If the reminder updated
         * successfully. 2. 404(NOT FOUND) - If the reminder with specified reminderId
         * is not found. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP PUT
         * method.
         */

        /*
         * Define a handler method which will get us the reminders by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the reminder found successfully.
         * 
         * This handler method should map to the URL "/api/reminder/{userId}" using HTTP GET method
         */

        /*
         * Define a handler method which will show details of a specific reminder handle
         * ReminderNotFoundException as well. This handler method should return any one
         * of the status messages basis on different situations: 1. 200(OK) - If the
         * reminder found successfully. 2. 404(NOT FOUND) - If the reminder
         * with specified reminderId is not found. This handler method should map to the
         * URL "/api/reminder/{id}" using HTTP GET method where "id" should be replaced by a
         * valid reminderId without {}
         */
    }
}
