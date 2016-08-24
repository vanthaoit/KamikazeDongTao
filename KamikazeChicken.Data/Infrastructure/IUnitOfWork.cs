namespace KamikazeChicken.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}