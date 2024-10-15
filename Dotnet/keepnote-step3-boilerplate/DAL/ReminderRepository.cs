using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class ReminderRepository : IReminderRepository
    {
        private readonly KeepDbContext _dbContext;
        public ReminderRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            _dbContext.Reminders.Add(reminder);
            _dbContext.SaveChanges();
            return reminder;
        }
        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            var reminder = _dbContext.Reminders.Find(reminderId);
            if (reminder != null)
            {
                _dbContext.Reminders.Remove(reminder);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }
        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            return _dbContext.Reminders.Where(r => r.ReminderCreatedBy == userId).ToList();
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            return _dbContext.Reminders.Find(reminderId);
        }
        // This method should be used to update a existing reminder.
        public bool UpdateReminder(Reminder reminder)
        {
            _dbContext.Reminders.Update(reminder);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
