var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var httpClient = new HttpClient();

app.MapPost("/orders", async (string customerId) =>
{
    var response = await httpClient.GetAsync($"https://customer-service.azurewebsites.net/customers/{customerId}");

    if (!response.IsSuccessStatusCode)
        return Results.BadRequest("Customer not found");

    var customerJson = await response.Content.ReadAsStringAsync();

    var order = new
    {
        orderId = Guid.NewGuid(),
        customer = customerJson,
        status = "Created"
    };

    return Results.Ok(order);
});

app.Run();