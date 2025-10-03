using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Database;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.DTOs.Users;

namespace UserManagementAPI.Services
{
    /// <summary>
    /// Service layer for user-related business logic
    /// </summary>
    public class UserService : IUserService
    {
        private readonly Database.ApplicationDbContext _context;

        public UserService(Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();

            return users.Select(MapToDto);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? null : MapToDto(user);
        }

        public async Task<ServiceResult<UserDto>> CreateUserAsync(CreateUserDto userDto)
        {
            // Validate email uniqueness
            if (await EmailExistsAsync(userDto.Email))
            {
                return ServiceResult<UserDto>.Failure($"User with email '{userDto.Email}' already exists");
            }

            var user = new User
            {
                Name = userDto.Name.Trim(),
                Email = userDto.Email.Trim().ToLower(),
                Age = userDto.Age,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return ServiceResult<UserDto>.SuccessResult(MapToDto(user));
        }

        public async Task<ServiceResult<UserDto>> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return ServiceResult<UserDto>.Failure($"User with ID {id} not found");
            }

            // Update email if provided and validate uniqueness
            if (!string.IsNullOrWhiteSpace(userDto.Email))
            {
                var normalizedEmail = userDto.Email.Trim().ToLower();
                if (normalizedEmail != user.Email && await EmailExistsAsync(normalizedEmail, id))
                {
                    return ServiceResult<UserDto>.Failure($"Email '{userDto.Email}' is already in use by another user");
                }
                user.Email = normalizedEmail;
            }

            // Update other fields if provided
            if (!string.IsNullOrWhiteSpace(userDto.Name))
                user.Name = userDto.Name.Trim();
            
            if (userDto.Age.HasValue)
                user.Age = userDto.Age.Value;

            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            
            return ServiceResult<UserDto>.SuccessResult(MapToDto(user));
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
            return true;
        }

        /// <summary>
        /// Checks if an email already exists in the database
        /// </summary>
        private async Task<bool> EmailExistsAsync(string email, int? excludeUserId = null)
        {
            var normalizedEmail = email.ToLower();
            return await _context.Users.AnyAsync(u => 
                u.Email == normalizedEmail && 
                (excludeUserId == null || u.Id != excludeUserId));
        }

        /// <summary>
        /// Maps User entity to UserDto
        /// </summary>
        private static UserDto MapToDto(User user) => new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Age = user.Age,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}