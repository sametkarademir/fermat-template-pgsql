using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fermat.Template.PgSql.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordLastSetTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    Group = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    IsEncrypted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EntityName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    SnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Fingerprint = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExceptionType = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    StackTrace = table.Column<string>(type: "text", nullable: true),
                    InnerExceptions = table.Column<string>(type: "text", nullable: true),
                    ExceptionData = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Details = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    StatusCode = table.Column<int>(type: "integer", nullable: false),
                    SnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HttpRequestLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HttpMethod = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    RequestPath = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    QueryString = table.Column<string>(type: "text", nullable: true),
                    RequestBody = table.Column<string>(type: "text", nullable: true),
                    RequestHeaders = table.Column<string>(type: "text", nullable: true),
                    StatusCode = table.Column<int>(type: "integer", nullable: true),
                    RequestTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResponseTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DurationMs = table.Column<long>(type: "bigint", nullable: true),
                    ClientIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UserAgent = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    DeviceFamily = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeviceModel = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    OsFamily = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    OsVersion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BrowserFamily = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BrowserVersion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsMobile = table.Column<bool>(type: "boolean", nullable: false),
                    IsTablet = table.Column<bool>(type: "boolean", nullable: false),
                    IsDesktop = table.Column<bool>(type: "boolean", nullable: false),
                    ControllerName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ActionName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpRequestLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientSecret = table.Column<string>(type: "text", nullable: true),
                    ClientType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ConsentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    DisplayNames = table.Column<string>(type: "text", nullable: true),
                    JsonWebKeySet = table.Column<string>(type: "text", nullable: true),
                    Permissions = table.Column<string>(type: "text", nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    RedirectUris = table.Column<string>(type: "text", nullable: true),
                    Requirements = table.Column<string>(type: "text", nullable: true),
                    Settings = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Descriptions = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    DisplayNames = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    Resources = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnapshotLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ApplicationVersion = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Environment = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    MachineName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    MachineOsVersion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Platform = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    CultureInfo = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    CpuCoreCount = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    CpuArchitecture = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    TotalRam = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    TotalDiskSpace = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    FreeDiskSpace = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    IpAddress = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    Hostname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnapshotLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationRoleClaims_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserClaims_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_ApplicationUserLogins_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRoles_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRoles_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserAgent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DeviceFamily = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    DeviceModel = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    OsFamily = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    OsVersion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    BrowserFamily = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    BrowserVersion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    IsMobile = table.Column<bool>(type: "boolean", nullable: false),
                    IsDesktop = table.Column<bool>(type: "boolean", nullable: false),
                    IsTablet = table.Column<bool>(type: "boolean", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    SnapshotId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSessions_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUserSessions_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTokens_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PropertyTypeFullName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    NewValue = table.Column<string>(type: "text", nullable: true),
                    OriginalValue = table.Column<string>(type: "text", nullable: true),
                    AuditLogId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityPropertyChanges_AuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationId = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    Scopes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_Application~",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SnapshotAppSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    SnapshotLogId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnapshotAppSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SnapshotAppSettings_SnapshotLogs_SnapshotLogId",
                        column: x => x.SnapshotLogId,
                        principalTable: "SnapshotLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SnapshotAssemblies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Version = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Culture = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    PublicKeyToken = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Location = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    SnapshotLogId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnapshotAssemblies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SnapshotAssemblies_SnapshotLogs_SnapshotLogId",
                        column: x => x.SnapshotLogId,
                        principalTable: "SnapshotLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationId = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReferenceId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoleClaims_RoleId",
                table: "ApplicationRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_CreationTime",
                table: "ApplicationRoles",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_CreatorId",
                table: "ApplicationRoles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_DeleterId",
                table: "ApplicationRoles",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_DeletionTime",
                table: "ApplicationRoles",
                column: "DeletionTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_IsDeleted",
                table: "ApplicationRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_LastModificationTime",
                table: "ApplicationRoles",
                column: "LastModificationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_LastModifierId",
                table: "ApplicationRoles",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_NormalizedName_DeletionTime",
                table: "ApplicationRoles",
                columns: new[] { "NormalizedName", "DeletionTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "ApplicationRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserClaims_UserId",
                table: "ApplicationUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserLogins_UserId",
                table: "ApplicationUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_CreationTime",
                table: "ApplicationUserRoles",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_CreatorId",
                table: "ApplicationUserRoles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_DeleterId",
                table: "ApplicationUserRoles",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_DeletionTime",
                table: "ApplicationUserRoles",
                column: "DeletionTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_IsDeleted",
                table: "ApplicationUserRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_LastModificationTime",
                table: "ApplicationUserRoles",
                column: "LastModificationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_LastModifierId",
                table: "ApplicationUserRoles",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_RoleId",
                table: "ApplicationUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_UserId_RoleId",
                table: "ApplicationUserRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ApplicationUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_CreationTime",
                table: "ApplicationUsers",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_CreatorId",
                table: "ApplicationUsers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_DeleterId",
                table: "ApplicationUsers",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_DeletionTime",
                table: "ApplicationUsers",
                column: "DeletionTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_IsDeleted",
                table: "ApplicationUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_LastModificationTime",
                table: "ApplicationUsers",
                column: "LastModificationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_LastModifierId",
                table: "ApplicationUsers",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_NormalizedEmail_DeletionTime",
                table: "ApplicationUsers",
                columns: new[] { "NormalizedEmail", "DeletionTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_NormalizedUserName_DeletionTime",
                table: "ApplicationUsers",
                columns: new[] { "NormalizedUserName", "DeletionTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ApplicationUsers",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_ApplicationUserId",
                table: "ApplicationUserSessions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_ClientIp",
                table: "ApplicationUserSessions",
                column: "ClientIp");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_CorrelationId",
                table: "ApplicationUserSessions",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_CreationTime",
                table: "ApplicationUserSessions",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_CreatorId",
                table: "ApplicationUserSessions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_DeleterId",
                table: "ApplicationUserSessions",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_DeletionTime",
                table: "ApplicationUserSessions",
                column: "DeletionTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_IsDeleted",
                table: "ApplicationUserSessions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_IsDesktop",
                table: "ApplicationUserSessions",
                column: "IsDesktop");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_IsMobile",
                table: "ApplicationUserSessions",
                column: "IsMobile");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_IsTablet",
                table: "ApplicationUserSessions",
                column: "IsTablet");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_LastModificationTime",
                table: "ApplicationUserSessions",
                column: "LastModificationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_LastModifierId",
                table: "ApplicationUserSessions",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_SnapshotId",
                table: "ApplicationUserSessions",
                column: "SnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSessions_UserId",
                table: "ApplicationUserSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_CreationTime",
                table: "AppSettings",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_CreatorId",
                table: "AppSettings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_DeleterId",
                table: "AppSettings",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_DeletionTime",
                table: "AppSettings",
                column: "DeletionTime");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_Group",
                table: "AppSettings",
                column: "Group");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_IsActive",
                table: "AppSettings",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_IsDeleted",
                table: "AppSettings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_Key_DeletionTime",
                table: "AppSettings",
                columns: new[] { "Key", "DeletionTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_LastModificationTime",
                table: "AppSettings",
                column: "LastModificationTime");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_LastModifierId",
                table: "AppSettings",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_Type",
                table: "AppSettings",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_CorrelationId",
                table: "AuditLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_CreationTime",
                table: "AuditLogs",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_CreatorId",
                table: "AuditLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_EntityId",
                table: "AuditLogs",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_EntityName",
                table: "AuditLogs",
                column: "EntityName");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_SessionId",
                table: "AuditLogs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_SnapshotId",
                table: "AuditLogs",
                column: "SnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_State",
                table: "AuditLogs",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPropertyChanges_AuditLogId",
                table: "EntityPropertyChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPropertyChanges_CreationTime",
                table: "EntityPropertyChanges",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPropertyChanges_CreatorId",
                table: "EntityPropertyChanges",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_Code",
                table: "ExceptionLogs",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_CorrelationId",
                table: "ExceptionLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_CreationTime",
                table: "ExceptionLogs",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_CreatorId",
                table: "ExceptionLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_ExceptionType",
                table: "ExceptionLogs",
                column: "ExceptionType");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_Fingerprint",
                table: "ExceptionLogs",
                column: "Fingerprint");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_SessionId",
                table: "ExceptionLogs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_SnapshotId",
                table: "ExceptionLogs",
                column: "SnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_StatusCode",
                table: "ExceptionLogs",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_Timestamp",
                table: "ExceptionLogs",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_ActionName",
                table: "HttpRequestLogs",
                column: "ActionName");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_BrowserFamily",
                table: "HttpRequestLogs",
                column: "BrowserFamily");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_BrowserVersion",
                table: "HttpRequestLogs",
                column: "BrowserVersion");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_ClientIp",
                table: "HttpRequestLogs",
                column: "ClientIp");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_ControllerName",
                table: "HttpRequestLogs",
                column: "ControllerName");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_CorrelationId",
                table: "HttpRequestLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_CreationTime",
                table: "HttpRequestLogs",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_CreatorId",
                table: "HttpRequestLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_DeviceFamily",
                table: "HttpRequestLogs",
                column: "DeviceFamily");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_DeviceModel",
                table: "HttpRequestLogs",
                column: "DeviceModel");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_HttpMethod",
                table: "HttpRequestLogs",
                column: "HttpMethod");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_OsFamily",
                table: "HttpRequestLogs",
                column: "OsFamily");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_OsVersion",
                table: "HttpRequestLogs",
                column: "OsVersion");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_RequestPath",
                table: "HttpRequestLogs",
                column: "RequestPath");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_SessionId",
                table: "HttpRequestLogs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpRequestLogs_SnapshotId",
                table: "HttpRequestLogs",
                column: "SnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                table: "OpenIddictAuthorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                table: "OpenIddictTokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotAppSettings_CreationTime",
                table: "SnapshotAppSettings",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotAppSettings_CreatorId",
                table: "SnapshotAppSettings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotAppSettings_Key",
                table: "SnapshotAppSettings",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotAppSettings_SnapshotLogId",
                table: "SnapshotAppSettings",
                column: "SnapshotLogId");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotAppSettings_Value",
                table: "SnapshotAppSettings",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotAssemblies_CreationTime",
                table: "SnapshotAssemblies",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotAssemblies_CreatorId",
                table: "SnapshotAssemblies",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotAssemblies_Name",
                table: "SnapshotAssemblies",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotAssemblies_SnapshotLogId",
                table: "SnapshotAssemblies",
                column: "SnapshotLogId");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotLogs_ApplicationName",
                table: "SnapshotLogs",
                column: "ApplicationName");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotLogs_ApplicationVersion",
                table: "SnapshotLogs",
                column: "ApplicationVersion");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotLogs_CreationTime",
                table: "SnapshotLogs",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotLogs_CreatorId",
                table: "SnapshotLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotLogs_Environment",
                table: "SnapshotLogs",
                column: "Environment");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotLogs_Hostname",
                table: "SnapshotLogs",
                column: "Hostname");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotLogs_IpAddress",
                table: "SnapshotLogs",
                column: "IpAddress");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotLogs_MachineName",
                table: "SnapshotLogs",
                column: "MachineName");

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotLogs_Platform",
                table: "SnapshotLogs",
                column: "Platform");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationRoleClaims");

            migrationBuilder.DropTable(
                name: "ApplicationUserClaims");

            migrationBuilder.DropTable(
                name: "ApplicationUserLogins");

            migrationBuilder.DropTable(
                name: "ApplicationUserRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUserSessions");

            migrationBuilder.DropTable(
                name: "ApplicationUserTokens");

            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "EntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "ExceptionLogs");

            migrationBuilder.DropTable(
                name: "HttpRequestLogs");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "SnapshotAppSettings");

            migrationBuilder.DropTable(
                name: "SnapshotAssemblies");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "SnapshotLogs");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");
        }
    }
}
