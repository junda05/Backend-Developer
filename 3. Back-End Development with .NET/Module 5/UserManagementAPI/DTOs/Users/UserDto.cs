using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.DTOs.Users
{
    /// <summary>
    /// DTO for reading user data
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// DTO for creating a new user
    /// </summary>
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;
        
        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120")]
        public int Age { get; set; }
    }

    /// <summary>
    /// DTO for updating an existing user
    /// </summary>
    public class UpdateUserDto
    {
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string? Name { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }
        
        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120")]
        public int? Age { get; set; }
    }
}