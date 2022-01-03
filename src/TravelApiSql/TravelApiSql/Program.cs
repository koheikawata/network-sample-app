using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelApiSql.Authentication;
using TravelApiSql.Data;
using TravelApiSql.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<TravelContext>(options =>
{
    SqlAuthenticationProvider.SetProvider(SqlAuthenticationMethod.ActiveDirectoryDefault, new CustomAzureSQLAuthProvider());
    options.UseSqlServer(new SqlConnection(builder.Configuration.GetValue<string>("SqlConnectionString")));
});
builder.Services.AddScoped<IEfRepository, EfRepository>();
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

// DbInitializer if DACPAC deployment is not used
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<TravelContext>();
//    context.Database.EnsureCreated();
//    DbInitializer.Initialize(context);
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
