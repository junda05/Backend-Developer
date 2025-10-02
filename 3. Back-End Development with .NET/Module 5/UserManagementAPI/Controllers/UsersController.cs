using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.DTOs.Users;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of all users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                _logger.LogInformation("Retrieving all users");
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all users");
                return StatusCode(500, "An error occurred while retrieving users");
            }
        }

        /// <summary>
        /// Get a specific user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User details</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving user with ID: {UserId}", id);
                var user = await _userService.GetUserByIdAsync(id);
                
                if (user == null)
                {
                    _logger.LogWarning("User with ID {UserId} not found", id);
                    return NotFound($"User with ID {id} not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user with ID: {UserId}", id);
                return StatusCode(500, "An error occurred while retrieving the user");
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="userDto">User creation data</param>
        /// <returns>Created user</returns>
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if email already exists
                if (await _userService.EmailExistsAsync(userDto.Email))
                {
                    return Conflict($"User with email '{userDto.Email}' already exists");
                }

                _logger.LogInformation("Creating new user with email: {Email}", userDto.Email);
                var user = await _userService.CreateUserAsync(userDto);
                
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user with email: {Email}", userDto.Email);
                return StatusCode(500, "An error occurred while creating the user");
            }
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="userDto">User update data</param>
        /// <returns>Updated user</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if user exists
                if (!await _userService.UserExistsAsync(id))
                {
                    return NotFound($"User with ID {id} not found");
                }

                // Check email uniqueness if email is being updated
                if (!string.IsNullOrEmpty(userDto.Email))
                {
                    if (await _userService.EmailExistsAsync(userDto.Email, id))
                    {
                        return Conflict($"Email '{userDto.Email}' is already in use by another user");
                    }
                }

                _logger.LogInformation("Updating user with ID: {UserId}", id);
                var updatedUser = await _userService.UpdateUserAsync(id, userDto);
                
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user with ID: {UserId}", id);
                return StatusCode(500, "An error occurred while updating the user");
            }
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Success message</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation("Deleting user with ID: {UserId}", id);
                var success = await _userService.DeleteUserAsync(id);
                
                if (!success)
                {
                    _logger.LogWarning("User with ID {UserId} not found for deletion", id);
                    return NotFound($"User with ID {id} not found");
                }

                return Ok($"User with ID {id} has been successfully deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user with ID: {UserId}", id);
                return StatusCode(500, "An error occurred while deleting the user");
            }
        }
    }
}