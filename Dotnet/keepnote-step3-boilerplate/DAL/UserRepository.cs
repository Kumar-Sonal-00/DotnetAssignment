using System;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class UserRepository : IUserRepository
    {
        private readonly KeepDbContext _dbContext;
        public UserRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            var user = _dbContext.Users.Find(userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }
        //This method should be used to get a user by userId.
        public User GetUserById(string userId)
        {
            return _dbContext.Users.Find(userId);
        }
        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges() > 0;
        }
        //This method should be used to update an existing user.
        public bool UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            return _dbContext.SaveChanges() > 0;
        }
        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(string userId, string password)
        {
            throw new NotImplementedException();
            //  return _dbContext.Users.FirstOrDefault(u => u.UserId == userId && u.Password == password);
        }
    }
}
