var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var products = new List<Product>
{
    new Product(1, "Laptop", 999.99m),
    new Product(2, "Mouse", 29.99m),
    new Product(3, "Keyboard", 59.99m)
};

app.MapGet("/products", () => Results.Ok(products));
app.MapGet("/products/{id}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});
app.MapPost("/products", (Product product) =>
{
    products.Add(product);
    return Results.Created($"/products/{product.Id}", product);
});
app.MapDelete("/products/{id}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    if (product is null) return Results.NotFound();
    products.Remove(product);
    return Results.NoContent();
});
app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.Run();

record Product(int Id, string Name, decimal Price);