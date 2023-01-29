var builder = WebApplication.CreateBuilder(args);

// using MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// to map from MVC
// Controller , action(fun)
app.MapDefaultControllerRoute();

app.Run();
