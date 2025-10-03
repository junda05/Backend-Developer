using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorHandlingController : ControllerBase
    {
        [HttpGet("division")]
        public IActionResult GetDivisionResult(int numerator, int denominator)
        {
            try
            {
                var result = numerator / denominator;
                return Ok(result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Zero division is not allowed.");
                return BadRequest("Can not divide by zero.");
            }
        }
    }
}