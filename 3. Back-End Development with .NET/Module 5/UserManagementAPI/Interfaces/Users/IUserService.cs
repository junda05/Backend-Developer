using UserManagementAPI.Services;
using UserManagementAPI.DTOs.Users;

namespace UserManagementAPI.Interfaces
{
    /// <summary>
    /// Interface for user service operations
    /// </summary>
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<ServiceResult<UserDto>> CreateUserAsync(CreateUserDto userDto);
        Task<ServiceResult<UserDto>> UpdateUserAsync(int id, UpdateUserDto userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}