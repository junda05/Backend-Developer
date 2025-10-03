using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Interfaces;
using UserManagementAPI.DTOs.Users;

namespace UserManagementAPI.Controllers
{
    /// <summary>
    /// Controller for managing user operations
    /// </summary>
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
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            _logger.LogInformation("Retrieving all users");
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Get a specific user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            _logger.LogInformation("Retrieving user with ID: {UserId}", id);
            var user = await _userService.GetUserByIdAsync(id);
            
            if (user == null)
            {
                _logger.LogWarning("User with ID {UserId} not found", id);
                return NotFound(new { message = $"User with ID {id} not found" });
            }

            return Ok(user);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="userDto">User data to create</param>
        /// <returns>Created user</returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto userDto)
        {
            _logger.LogInformation("Creating new user with email: {Email}", userDto.Email);
            
            var result = await _userService.CreateUserAsync(userDto);
            
            if (!result.Success)
                return Conflict(new { message = result.ErrorMessage });

            return CreatedAtAction(nameof(GetUser), new { id = result.Data!.Id }, result.Data);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="userDto">User data to update</param>
        /// <returns>Updated user</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            _logger.LogInformation("Updating user with ID: {UserId}", id);
            
            var result = await _userService.UpdateUserAsync(id, userDto);
            
            if (!result.Success)
            {
                if (result.ErrorMessage!.Contains("not found"))
                    return NotFound(new { message = result.ErrorMessage });
                
                return Conflict(new { message = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Success message</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUser(int id)
        {
            _logger.LogInformation("Deleting user with ID: {UserId}", id);
            
            var success = await _userService.DeleteUserAsync(id);
            
            if (!success)
            {
                _logger.LogWarning("User with ID {UserId} not found for deletion", id);
                return NotFound(new { message = $"User with ID {id} not found" });
            }

            return Ok(new { message = $"User with ID {id} has been successfully deleted" });
        }
    }
}