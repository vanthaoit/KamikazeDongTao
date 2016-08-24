namespace KamikazeChicken.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private KamikazeChickenDbContext dbContext;
        public KamikazeChickenDbContext Init()
        {
            return dbContext ?? (dbContext = new KamikazeChickenDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}