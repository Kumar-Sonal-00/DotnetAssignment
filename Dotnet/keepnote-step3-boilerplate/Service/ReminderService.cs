using System.Collections.Generic;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
   * Service classes are used here to implement additional business logic/validation
   * */
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;
        /*
        Use constructor Injection to inject all required dependencies.
        */
        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            // Validate Reminder properties (if necessary)
            if (_reminderRepository.GetReminderById(reminder.ReminderId) != null)
            {
                throw new ReminderNotFoundException($"Reminder with id {reminder.ReminderId} already exists.");
            }

            return _reminderRepository.CreateReminder(reminder);
        }

        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            var reminder = _reminderRepository.GetReminderById(reminderId);
            if (reminder == null)
            {
                throw new ReminderNotFoundException("Reminder not found");
            }
            return _reminderRepository.DeletReminder(reminderId); 
        }

        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            var reminders = _reminderRepository.GetAllRemindersByUserId(userId);
            if (reminders == null || reminders.Count == 0)
            {
                throw new ReminderNotFoundException($"No reminders found for user with id {userId}.");
            }

            return reminders;
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            var reminder = _reminderRepository.GetReminderById(reminderId);
            if (reminder == null)
            {
                throw new ReminderNotFoundException($"Reminder with id {reminderId} not found.");
            }

            return reminder;
        }

        // This method should be used to update a existing reminder.
        public bool UpdateReminder(int reminderId, Reminder reminder)
        {
            var existingReminder = _reminderRepository.GetReminderById(reminderId);
            if (existingReminder == null)
            {
                throw new ReminderNotFoundException("Reminder not found");
            }
            return _reminderRepository.UpdateReminder(reminder);
        }
    }
}
