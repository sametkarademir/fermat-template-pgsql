using Fermat.EntityFramework.Shared.Interfaces;
using Fermat.Template.PgSql.Domain.Entities;

namespace Fermat.Template.PgSql.Application.Repositories;

public interface IAppSettingRepository : IRepository<AppSetting, Guid>
{

}