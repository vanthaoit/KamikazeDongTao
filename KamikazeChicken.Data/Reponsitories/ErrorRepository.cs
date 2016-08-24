using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Model.Models;

namespace KamikazeChicken.Data.Reponsitories
{
    public interface IErrorRepository : IRepository<Error>
    {
    }

    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory DbFactory) : base(DbFactory)
        {
        }
    }
}