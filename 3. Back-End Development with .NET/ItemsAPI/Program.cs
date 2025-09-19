var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Item> items = new List<Item> { };

// Get all items
app.MapGet("/items", () =>
{
    return items;
});
// Get item by id
app.MapGet("/items/{id}", (int id) =>
{
    var item = items.FirstOrDefault(item => item.Id == id);
    if (item == null) return Results.NotFound("Item not found");
    return Results.Ok(item);
    // if (id < 0 || id >= items.Count)
    // {
    //     return Results.NotFound();
    // }
    // else
    // {
    //     return Results.Ok(items[id + 1]);
    // }
});

// Post items
app.MapPost("/items", (Item newItem) =>
{
    if (newItem == null) return Results.BadRequest("Invalid item");
    newItem.Id = items.Count + 1;
    items.Add(newItem);
    return Results.Created($"/items/{newItem.Id}", newItem);
});

// Put items
app.MapPut("/items/{id}", (int id, Item updatedItem) =>
{
    var item = items.FirstOrDefault(item => item.Id == id);
    if (item == null) return Results.NotFound("Item not found");
    item.Name = updatedItem.Name;
    item.Description = updatedItem.Description;
    item.Price = updatedItem.Price;
    return Results.Ok(item);
});

// Delete items
app.MapDelete("/items/{id}", (int id) =>
{
    var item = items.FirstOrDefault(item => item.Id == id);
    if (item == null) return Results.NotFound("Item not found");
    items.Remove(item);
    return Results.NoContent(); 
});

app.Run();