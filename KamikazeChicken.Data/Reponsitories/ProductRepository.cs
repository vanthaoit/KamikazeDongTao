using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Model.Models;

namespace KamikazeChicken.Data.Reponsitories
{
    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory DbFactory) : base(DbFactory)
        {
        }
    }
}