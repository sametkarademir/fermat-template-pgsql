
using Fermat.Domain.Extensions.ServiceCollections;
using Fermat.Domain.Shared.Conventions;
using Fermat.EntityFramework.AuditLogs.DependencyInjection;
using Fermat.EntityFramework.AuditLogs.Domain.Enums;
using Fermat.EntityFramework.ExceptionLogs.DependencyInjection;
using Fermat.EntityFramework.HttpRequestLogs.DependencyInjection;
using Fermat.EntityFramework.Identity.DependencyInjection;
using Fermat.EntityFramework.SnapshotLogs.DependencyInjection;
using Fermat.Template.PgSql.Application;
using Fermat.Template.PgSql.Infrastructure;
using Fermat.Template.PgSql.Persistence;
using Fermat.Template.PgSql.Persistence.Contexts;
using Fermat.Template.PgSql.Shared.Constants;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplicationExtensions();
builder.Services.AddInfrastructureExtensions();
builder.Services.AddPersistenceExtensions(builder.Configuration);

#region AddAuditLog

builder.Services.AddFermatAuditLogServices<ApplicationDbContext>(opt =>
{
    opt.Enabled = true;
    opt.MaskPattern = "***MASKED***";
    opt.SensitiveProperties =
    [
        "Password",
        "Token",
        "Secret",
        "ApiKey",
        "Key",
        "Credential",
        "Ssn",
        "Credit",
        "Card",
        "SecurityCode",
        "Pin",
        "Authorization"
    ];
    opt.ExcludedPropertiesByEntityType = new Dictionary<Type, HashSet<string>>
    {
        //{ typeof(Todo), ["AssignedTo"] }
    };
    opt.IncludedEntityTypes =
    [
        //typeof(Todo) 
    ];
    opt.ExcludedEntityTypes =
    [
        //typeof(Todo) 
    ];
    opt.LogChangeDetails = true;
    opt.MaxValueLength = 5000;
    opt.LoggedStates =
    [
        States.Added,
        States.Modified,
        States.Deleted
    ];
    opt.AuditLogController.Enabled = true;
    opt.AuditLogController.Route = "api/audit-logs";
    opt.AuditLogController.GlobalAuthorization.RequireAuthentication = true;
    opt.AuditLogController.GlobalAuthorization.Roles = [ApplicationRoleConstans.AdminRoleName];
});

#endregion

#region AddHttpRequestLog

builder.Services.AddFermatHttpRequestLogServices<ApplicationDbContext>(opt =>
{
    opt.Enabled = true;
    opt.ExcludedPaths = ["/api/health"];
    opt.ExcludedHttpMethods = ["OPTIONS"];
    opt.ExcludedContentTypes = ["application/octet-stream", "application/pdf", "image/", "video/", "audio/"];
    opt.LogRequestBody = true;
    opt.MaxRequestBodyLength = 5000;
    opt.LogOnlySlowRequests = true;
    opt.SlowRequestThresholdMs = 10;
    opt.MaskPattern = "***MASKED***";
    opt.RequestBodySensitiveProperties =
        ["Password", "Token", "Secret", "Key", "Credential", "Ssn", "Credit", "Card", "Description"];
    opt.QueryStringSensitiveProperties = ["Password", "Token", "Secret", "ApiKey", "Key"];
    opt.HeaderSensitiveProperties = ["Authorization", "Cookie", "X-Api-Key"];
    opt.HttpRequestLogController.Enabled = true;
    opt.HttpRequestLogController.Route = "api/http-request-logs";
    opt.HttpRequestLogController.GlobalAuthorization.RequireAuthentication = true;
    opt.HttpRequestLogController.GlobalAuthorization.Roles = [ApplicationRoleConstans.AdminRoleName];
});

#endregion

#region AddSnapshotLog

builder.Services.AddFermatSnapshotLogServices<ApplicationDbContext>(opt =>
{
    opt.Enabled = true;
    opt.IsSnapshotAssemblyEnabled = false;
    opt.IsSnapshotAppSettingEnabled = false;

    opt.SnapshotLogController.Enabled = true;
    opt.SnapshotLogController.Route = "api/snapshot-logs";
    opt.SnapshotLogController.GlobalAuthorization.RequireAuthentication = true;
    opt.SnapshotLogController.GlobalAuthorization.Roles = [ApplicationRoleConstans.AdminRoleName];

    opt.SnapshotAssemblyController.Enabled = true;
    opt.SnapshotAssemblyController.Route = "api/snapshot-assemblies";
    opt.SnapshotAssemblyController.GlobalAuthorization.RequireAuthentication = true;
    opt.SnapshotAssemblyController.GlobalAuthorization.Roles = [ApplicationRoleConstans.AdminRoleName];

    opt.SnapshotAppSettingController.Enabled = true;
    opt.SnapshotAppSettingController.Route = "api/snapshot-app-settings";
    opt.SnapshotAppSettingController.GlobalAuthorization.RequireAuthentication = true;
    opt.SnapshotAppSettingController.GlobalAuthorization.Roles = [ApplicationRoleConstans.AdminRoleName];
});

#endregion

#region AddExceptionLog

builder.AddFermatExceptionLogServices<ApplicationDbContext>(opt =>
{
    opt.Serilog.Enabled = true;
    opt.Serilog.Console.Enabled = true;
    opt.Serilog.Console.OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
    opt.Serilog.Console.Theme = AnsiConsoleTheme.Code;
    opt.Serilog.Console.MinimumLevel = Serilog.Events.LogEventLevel.Verbose;
    opt.Serilog.File.Enabled = true;
    opt.Serilog.File.PathToTxt = "logs/txt-.txt";
    opt.Serilog.File.PathToJson = "logs/json-.json";
    opt.Serilog.File.RollingInterval = Serilog.RollingInterval.Day;
    opt.Serilog.File.OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{Properties:j}{NewLine}{Exception}";
    opt.Serilog.WebhookOptions.Enabled = false;

    opt.ExceptionLogController.Enabled = true;
    opt.ExceptionLogController.Route = "api/exception-logs";
    opt.ExceptionLogController.GlobalAuthorization.RequireAuthentication = true;
    opt.ExceptionLogController.GlobalAuthorization.Roles = [ApplicationRoleConstans.AdminRoleName];
});

#endregion

#region AddIdentity

builder.Services.AddFermatIdentityServices<ApplicationDbContext>(opt =>
{
    opt.Enabled = true;
    opt.ConnectController.Enabled = true;

    opt.RoleController.Enabled = true;
    opt.RoleController.Route = "api/roles";
    opt.RoleController.GlobalAuthorization.RequireAuthentication = true;
    opt.UserRoleController.GlobalAuthorization.Roles = [ApplicationRoleConstans.AdminRoleName];

    opt.UserRoleController.Enabled = true;
    opt.UserRoleController.Route = "api/user-roles";
    opt.UserRoleController.GlobalAuthorization.RequireAuthentication = true;
    opt.UserRoleController.GlobalAuthorization.Roles = [ApplicationRoleConstans.AdminRoleName];

    opt.UserSessionController.Enabled = true;
    opt.UserSessionController.Route = "api/user-sessions";
    opt.UserSessionController.GlobalAuthorization.RequireAuthentication = true;
    opt.UserSessionController.GlobalAuthorization.Roles = [ApplicationRoleConstans.AdminRoleName];
    
    opt.UserProfileController.Enabled = true;
    opt.UserProfileController.Route = "api/user-profiles";
    opt.UserProfileController.GlobalAuthorization.RequireAuthentication = true;

    opt.UserController.Enabled = true;
    opt.UserController.Route = "api/users";
    opt.UserController.GlobalAuthorization.RequireAuthentication = true;
    opt.UserController.Endpoints =
    [
        new EndpointOptions
        {
            IsEnabled = true,
            ActionName = "GetById",
            RequireAuthentication = true,
            Roles = [ApplicationRoleConstans.AdminRoleName]
        },
        new EndpointOptions
        {
            IsEnabled = true,
            ActionName = "GetPageableAndFilter",
            RequireAuthentication = true,
            Roles = [ApplicationRoleConstans.AdminRoleName]
        },
        new EndpointOptions
        {
            IsEnabled = true,
            ActionName = "Create",
            RequireAuthentication = true,
            Roles = [ApplicationRoleConstans.AdminRoleName]
        },
        new EndpointOptions
        {
            IsEnabled = true,
            ActionName = "Update",
            RequireAuthentication = true,
            Roles = [ApplicationRoleConstans.AdminRoleName]
        },
        new EndpointOptions
        {
            IsEnabled = true,
            ActionName = "Delete",
            RequireAuthentication = true,
            Roles = [ApplicationRoleConstans.AdminRoleName]
        },
        new EndpointOptions
        {
            IsEnabled = true,
            ActionName = "ChangePassword",
            RequireAuthentication = true
        },
        new EndpointOptions
        {
            IsEnabled = true,
            ActionName = "Lock",
            RequireAuthentication = true,
            Roles = [ApplicationRoleConstans.AdminRoleName]
        },
        new EndpointOptions
        {
            IsEnabled = true,
            ActionName = "Unlock",
            RequireAuthentication = true,
            Roles = [ApplicationRoleConstans.AdminRoleName]
        }
    ];
});

builder.Services.AddFermatIdentitySeedService<ApplicationDbContext>(options =>
{
    options.Enabled = true;
    options.DefaultAdminUser.UserName = "admin";
    options.DefaultAdminUser.Email = "admin@example.com";
    options.DefaultAdminUser.Password = "Admin123!";
    options.DefaultRoles = ApplicationRoleConstans.AllRoles.ToList();
    options.OpenIddictClient.ClientId = "K7vQm9pX4sR8wN2jF6yU3zV5cB1nH9gL0oA8mE7iT4qD";
    options.OpenIddictClient.ClientSecret = "fermion-secret";
    options.OpenIddictClient.DisplayName = "Fermion Identity Client";
});

#endregion

builder.Services.AddSwaggerDocumentation(builder.Configuration);
var app = builder.Build();

app.FermatExceptionLogMiddleware();
app.FermatSnapshotLogMiddleware();
app.FermatHttpRequestLogMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.FermatIdentityMiddleware();

app.Run();