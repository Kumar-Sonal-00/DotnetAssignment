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
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        /*
        * NoteService should  be injected through constructor injection. Please note that we should not create service
        * object using the new keyword
        */
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            var createdNote = _noteService.CreateNote(note);
            return CreatedAtAction(nameof(GetNoteByNoteId), new { id = createdNote.NoteId }, createdNote);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note is null.");
            }

            var result = _noteService.UpdateNote(id, note);
            if (!result)
            {
                return NotFound($"Note with ID {id} not found.");
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var result = _noteService.DeleteNote(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound($"Note with id {id} not found");
        }

        [HttpGet("{id}")]
        public IActionResult GetNoteByNoteId(int id)
        {
            var note = _noteService.GetNoteByNoteId(id);
            if (note != null)
            {
                return Ok(note);
            }
            return NotFound($"Note with id {id} not found");
        }
        [HttpGet("user/{userId}")]
        public IActionResult GetAllNotesByUserId(string userId)
        {
            var notes = _noteService.GetAllNotesByUserId(userId);
            return Ok(notes);
        }

        /*
         * Define a handler method which will create a specific note by reading the
         * Serialized object from request body and save the note details in a Note table
         * in the database.Handle ReminderNotFoundException and
         * CategoryNotFoundException as well. please note that the userID
         * should be taken as the createdBy for the note.This handler method should
         * return any one of the status messages basis on different situations: 1.
         * 201(CREATED) - If the note created successfully. 2. 409(CONFLICT) - If the
         * noteId conflicts with any existing user
         * 
         * This handler method should map to the URL "/api/note" using HTTP POST method
         */

        /*
         * Define a handler method which will delete a note from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note deleted successfully from
         * database. 2. 404(NOT FOUND) - If the note with specified noteId is not found.
         * 
         * This handler method should map to the URL "/api/note/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid noteId without {}
         */

        /*
         * Define a handler method which will update a specific note by reading the
         * Serialized object from request body and save the updated note details in a
         * note table in database handle ReminderNotFoundException,
         * NoteNotFoundException, CategoryNotFoundException as well. please note that
         * the userID should be taken as the createdBy for the note. This
         * handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note updated successfully. 2.
         * 404(NOT FOUND) - If the note with specified noteId is not found.
         * This handler method should map to the URL "/api/note/{id}" using HTTP PUT method.
         */

        /*
         * Define a handler method which will get us the notes by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note found successfully.
         * 
         * This handler method should map to the URL "/api/note/{userId}" using HTTP GET method
         */
    }
}
