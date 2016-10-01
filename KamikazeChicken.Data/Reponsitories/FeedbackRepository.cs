using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Model.Models;

namespace KamikazeChicken.Data.Reponsitories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
    }

    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IDbFactory DbFactory) : base(DbFactory)
        {
        }
    }
}