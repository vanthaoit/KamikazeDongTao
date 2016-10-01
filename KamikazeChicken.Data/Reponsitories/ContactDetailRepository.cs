using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Model.Models;

namespace KamikazeChicken.Data.Reponsitories
{
    public interface IContactDetailRepository : IRepository<ContactDetail>
    {
    }

    public class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(IDbFactory DbFactory) : base(DbFactory)
        {
        }
    }
}