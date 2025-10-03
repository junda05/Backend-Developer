using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("{id}")]
    [Produces("application/json")]
    public ActionResult<User> GetUser(int id)
    {
        var user = new User 
        { 
            Id = id,
            Name = $"User {id}"
        };
        
        return Ok(user);
    }
}