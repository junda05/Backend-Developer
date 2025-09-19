using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private static List<Product> products = new List<Product>();

    // Get all products
    [HttpGet]
    public ActionResult<List<Product>> GetAll() => products;

    /// Get by id
    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = products.FirstOrDefault(products => products.Id == id);
        return product != null ? Ok(product) : NotFound();
    }

    // Post a product
    [HttpPost]
    public ActionResult<Product> Create(Product newProduct)
    {
        newProduct.Id = products.Count + 1;
        products.Add(newProduct);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }

    // Update a product
    [HttpPut("{id}")]
    public ActionResult Update(int id, Product updatedProduct)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        product.Name = updatedProduct.Name;
        product.Description = updatedProduct.Description;
        product.Price = updatedProduct.Price;

        return Ok(product);
    }

    /// Delete by id
    [HttpDelete("{id}")]
    public ActionResult<Product> Delete(int id)
    {
        var product = products.FirstOrDefault(products => products.Id == id);
        products.Remove(product);
        return product != null ? NoContent() : NotFound();
    }
}