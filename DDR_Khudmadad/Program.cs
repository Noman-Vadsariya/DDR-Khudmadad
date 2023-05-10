using DDR_Khudmadad.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using DDR_Khudmadad.DataSource;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<Ef_DataContext>(
//    o => o.UseSqlServer(builder.Configuration.GetConnectionString("AzureSqlDb"))
//);

//builder.Services.AddDbContext<Ef_DataContext>(
//    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DDR_Khudmadad"))
//    );

IDatabase db = new PostgresDb();

builder.Services.AddDbContext<Ef_DataContext>( options =>
        db.Configure(options, builder.Configuration.GetConnectionString("DDR_Khudmadad"))
    );

//Automatically perform migration
//builder.Services.BuildServiceProvider().GetService<Ef_DataContext>().Database.Migrate();

builder.Services.AddControllers();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "HelloWorld");

app.Run();
