using CoffeeShop.Middlewares;
using CoffeeShop.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataAccess(builder.Configuration)
    .AddBusinessLogic();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(CoffeeProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
