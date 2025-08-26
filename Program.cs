var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method}, {context.Request.Path}");
    await next();
    Console.WriteLine("Response sent");
});

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
{
    appBuilder.Use(async (context, next) =>
    {
        Console.WriteLine("API Request detected");
        await next();
    });
});

app.Map("/students", studentApp =>
{
    studentApp.Use(async (context, next) =>
    {
        Console.WriteLine("Inside Students branch");
        await next();
    });

    studentApp.Run(async context =>
    {
        await context.Response.WriteAsync("Student Management Section");
    });
});

app.Map("/teachers", teacherApp =>
{
    teacherApp.Run(async context =>
    {
        await context.Response.WriteAsync("Teacher Management Section");
    });
});

app.MapWhen(
    context => context.Request.Query.ContainsKey("admin") && context.Request.Query["admin"] == "true",
    adminApp =>
    {
        adminApp.Run(async context =>
        {
            await context.Response.WriteAsync("Admin Dashboard");
        });
    });

app.Map("/", async context =>
{
    await context.Response.WriteAsync(" Welcome to the Student Portal");
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Page not found");
});

app.Run();
