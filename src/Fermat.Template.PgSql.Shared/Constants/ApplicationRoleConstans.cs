namespace Fermat.Template.PgSql.Shared.Constants;

public static class ApplicationRoleConstans
{
    public const string AdminRoleName = "Admin";
    public const string UserRoleName = "User";

    public static readonly string[] AllRoles = [AdminRoleName, UserRoleName];
}