using ERP.Infrastructure.IocConfig;

var builder = WebApplication.CreateBuilder(args);

var Services = builder.Services;

// ───── Local Services ─────
Services.AddControllers();
Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();
Services.AddRepositoryServies();
Services.AddResponseCaching();
Services.AddMemoryCache();
Services.AddAutoMapperServies();

// ───── Custom Services ─────
Services.AddInfrastructureServices(builder.Configuration);
Services.AddMedaitRConfig();
Services.AddDbContextServies(builder.Configuration);     // Register DbContext
Services.AddIdentityServies();      // Register Identity
Services.AddLogicServies();         // Register application logic (e.g., services, handlers)

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Show detailed errors in dev
    app.UseSwagger();                // Enable Swagger
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseResponseCaching();
//app.UseCors("EnableCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // Map controller endpoints

// ───── Optional Middleware ─────
// app.UseApiVersioning();         // Enable if using versioning

app.Run();

// Optional for integration tests
// public partial class Program { }
