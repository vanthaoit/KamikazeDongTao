using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace KamikazeChicken.Data.Reponsitories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory DbFactory) : base(DbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}