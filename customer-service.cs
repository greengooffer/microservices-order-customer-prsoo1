var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/customers/{id}", (string id) =>
{
    var customer = new
    {
        id = id,
        firstName = "Олександр",
        lastName = "Ісаєв",
        address = new
        {
            street = "Kyivska 1",
            city = "Kyiv",
            zipCode = "01001"
        }
    };

    return Results.Ok(customer);
});

app.Run();