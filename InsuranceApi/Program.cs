using InsuranceApi;
using InsuranceCore;
using InsuranceInfrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
var service = builder.Services;

service.AddScoped<IPremiumService, PremiumService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? throw new Exception("Value can not be null");

//CORS: localhost:3000
service.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder
     .WithOrigins(allowedOrigins)
     .WithHeaders("Authorization", "origin", "accept", "content-type")
     .WithMethods("GET", "POST", "PUT", "DELETE")
     ;
    });
});
service.AddMvc(options =>
{

});

service.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();
app.MapGet("/", () => "success");

app.Run();
