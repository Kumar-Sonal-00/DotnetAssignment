using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
  * Service classes are used here to implement additional business logic/validation
  * */
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        /*
       Use constructor Injection to inject all required dependencies.
       */
        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }
        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new UserNotFoundException("User not found");
            }

            return _userRepository.DeleteUser(userId);
        }

        //This method should be used to get a user by userId.
        public User GetUserById(string userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new UserNotFoundException("User not found");
            }
            return user;
        }

        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            var existingUser = _userRepository.GetUserById(user.UserId);
            if (existingUser != null)
            {
                throw new UserAlreadyExistException("User already exists");
            }

            return _userRepository.RegisterUser(user);
        }

        //This method should be used to update an existing user.
        public bool UpdateUser(string userId, User user)
        {
            var existingUser = _userRepository.GetUserById(userId);
            if (existingUser == null)
            {
                throw new UserNotFoundException("User not found");
            }
            user.UserId = userId; // Assign the ID to the user object
            return _userRepository.UpdateUser(user);
        }

        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(string userId, string password)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null || user.Password != password)
            {
                throw new UserNotFoundException("Invalid credentials");
            }

            return true;
        }
    }
}
