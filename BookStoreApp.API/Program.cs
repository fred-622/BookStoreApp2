using BookStoreApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Vid 13
var connString = builder.Configuration.GetConnectionString("BookStoreAppDbConnection");
// Note dont add the following line till Db scafolding is done
builder.Services.AddDbContext<BookStoreDb2Context>(options => options.UseSqlServer(connString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Serilog vid 9
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

// Add CORS policy to relax autorization and allow all, we will implement authorization via Jwt tokes, vid 10
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy vid 10
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
