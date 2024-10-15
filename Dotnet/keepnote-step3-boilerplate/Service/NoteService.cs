using DAL;
using Entities;
using Exceptions;
using System.Collections.Generic;

namespace Service
{

    /*
   * Service classes are used here to implement additional business logic/validation
   * */
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IReminderRepository _reminderRepository;
        /*
         Use constructor Injection to inject all required dependencies.
             */
        public NoteService(INoteRepository repository, ICategoryRepository category, IReminderRepository reminder)
        {
            _noteRepository = repository;
            _categoryRepository = category;
            _reminderRepository = reminder;
        }

        /*
	     * This method should be used to save a new note.
	     */
        public Note CreateNote(Note note)
        {
            // Validate if the Category exists
            if (note.Category != null)
            {
                var category = _categoryRepository.GetCategoryById(note.Category.CategoryId);
                if (category == null)
                {
                    throw new CategoryNotFoundException($"Category with id {note.Category.CategoryId} not found");
                }
            }

            // Validate if the Reminder exists
            if (note.Reminder != null)
            {
                var reminder = _reminderRepository.GetReminderById(note.Reminder.ReminderId);
                if (reminder == null)
                {
                    throw new ReminderNotFoundException($"Reminder with id {note.Reminder.ReminderId} not found");
                }
            }

            // Save the note
            return _noteRepository.CreateNote(note);
        }
        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            var note = _noteRepository.GetNoteByNoteId(noteId);
            if (note == null)
            {
                throw new NoteNotFoundException($"Note with id {noteId} not found");
            }
            return _noteRepository.DeleteNote(noteId);
        }

        /*
	     * This method should be used to get all note by userId.
	     */
        public List<Note> GetAllNotesByUserId(string userId)
        {
            var notes = _noteRepository.GetAllNotesByUserId(userId);
            if (notes == null || notes.Count == 0)
            {
                throw new NoteNotFoundException($"No notes found for user with id {userId}");
            }
            return notes;
        }

        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            var note = _noteRepository.GetNoteByNoteId(noteId);
            if (note == null)
            {
                throw new NoteNotFoundException($"Note with id {noteId} not found");
            }
            return note;
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(int noteId, Note note)
        {
            var existingNote = _noteRepository.GetNoteByNoteId(noteId);
            if (existingNote == null)
            {
                throw new NoteNotFoundException($"Note with id {noteId} not found");
            }

            // Validate Category if exists
            if (note.Category != null)
            {
                var category = _categoryRepository.GetCategoryById(note.Category.CategoryId);
                if (category == null)
                {
                    throw new CategoryNotFoundException($"Category with id {note.Category.CategoryId} not found");
                }
            }
            // Validate Reminder if exists
            if (note.Reminder != null)
            {
                var reminder = _reminderRepository.GetReminderById(note.Reminder.ReminderId);
                if (reminder == null)
                {
                    throw new ReminderNotFoundException($"Reminder with id {note.Reminder.ReminderId} not found");
                }
            }

            // Update the note
            return _noteRepository.UpdateNote(note);
        }
    }
}
