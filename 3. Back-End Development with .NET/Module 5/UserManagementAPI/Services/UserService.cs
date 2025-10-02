using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.DTOs.Users;

namespace UserManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;
        private int _nextId;

        public UserService()
        {
            _users = new List<User>();
            _nextId = 1;
            
            // Seed with some initial data
            SeedData();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_users.AsEnumerable());
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return await Task.FromResult(user);
        }

        public async Task<User> CreateUserAsync(CreateUserDto userDto)
        {
            var user = new User
            {
                Id = _nextId++,
                Name = userDto.Name,
                Email = userDto.Email,
                Age = userDto.Age,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<User?> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return null;

            if (!string.IsNullOrEmpty(userDto.Name))
                user.Name = userDto.Name;
            
            if (!string.IsNullOrEmpty(userDto.Email))
                user.Email = userDto.Email;
            
            if (userDto.Age.HasValue)
                user.Age = userDto.Age.Value;

            user.UpdatedAt = DateTime.UtcNow;

            return await Task.FromResult(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return false;

            _users.Remove(user);
            return await Task.FromResult(true);
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            var exists = _users.Any(u => u.Id == id);
            return await Task.FromResult(exists);
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeUserId = null)
        {
            var exists = _users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && 
                                        (excludeUserId == null || u.Id != excludeUserId));
            return await Task.FromResult(exists);
        }

        private void SeedData()
        {
            _users.AddRange(new[]
            {
                new User
                {
                    Id = _nextId++,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Age = 30,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = _nextId++,
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Age = 25,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            });
        }
    }
}