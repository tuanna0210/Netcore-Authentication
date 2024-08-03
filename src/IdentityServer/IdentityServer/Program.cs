using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;
var defaultConnString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddIdentityServer()
    //Store used for configuration data such as clients, resources, and scopes
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(defaultConnString, opts => opts.MigrationsAssembly(assembly));
    })
    //Store used for temporary operational data such as authorization codes, and refresh tokens
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(defaultConnString, opts => opts.MigrationsAssembly(assembly));
    })
    .AddDeveloperSigningCredential();
var app = builder.Build();
app.UseIdentityServer();

app.Run();
