using Fermat.EntityFramework.Shared.Repositories;
using Fermat.Template.PgSql.Application.Repositories;
using Fermat.Template.PgSql.Domain.Entities;
using Fermat.Template.PgSql.Persistence.Contexts;

namespace Fermat.Template.PgSql.Persistence.Repositories;

public class AppSettingRepository : EfRepositoryBase<AppSetting, Guid, ApplicationDbContext>, IAppSettingRepository
{
    public AppSettingRepository(ApplicationDbContext context) : base(context)
    {
    }
}