// Controllers bridge HTTP requests and the logic required to generate responses, making them essential to an API.

// Defines a route: api/products
// Handles GET requests to that route
// Returns a list of strings as product names

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace MyFirstApi.Controllers
{
    [ApiController]
    // Means the route is based on the controller name (ProductsController → products)
    // Routing determines which controller and action handle a given request, making it a key part of request handling.
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult <List<string>> Get()
        {
            return new List<string> { "Apple", "Banana", "Orange" };
        }

        [HttpGet("featured")]
        public string GetFeaturedProduct() => "Mango";

        [HttpPost]
        public ActionResult<string> Post([FromBody] string newProduct)
        {
            return $"Added {newProduct}";
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] string updatedProduct)
        {
            return $"Updated product {id} to: {updatedProduct}";
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            return $"Deleted product with ID: {id}";
        }
    }
}