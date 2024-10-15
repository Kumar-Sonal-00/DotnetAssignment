using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class NoteRepository : INoteRepository
    {
        private readonly KeepDbContext _dbContext;
        public NoteRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // This method should be used to save a new note.
        public Note CreateNote(Note note)
        {
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
            return note;
        }

        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            var note = _dbContext.Notes.Find(noteId);
            if (note != null)
            {
                _dbContext.Notes.Remove(note);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        //* This method should be used to get all note by userId.
        public List<Note> GetAllNotesByUserId(string userId)
        {
            return _dbContext.Notes.Where(n => n.CreatedBy == userId).ToList();
        }
        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            return _dbContext.Notes.Find(noteId);
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(Note note)
        {
            _dbContext.Notes.Update(note);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
