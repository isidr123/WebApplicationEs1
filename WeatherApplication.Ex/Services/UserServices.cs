using WeatherApplication.Ex.DTO;

namespace WeatherApplication.Ex.Services
{
    public class UserService
    {
        private readonly List<UserDTO> _users = new();

        public void CreateUser(UserDTO user)
        {
            _users.Add(user);
        }

        public List<UserDTO> GetUsers()
        {
            return _users;
        }
    }
}
