namespace KamikazeChicken.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private KamikazeChickenDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {   
            this.dbFactory = dbFactory;
        }

        public KamikazeChickenDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}