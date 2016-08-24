using System;

namespace KamikazeChicken.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        KamikazeChickenDbContext Init();
    }
}