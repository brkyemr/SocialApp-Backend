using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Application.Interfaces.Repositories;
using SocialApp.Application.Interfaces.UnitOfWorks;
using SocialApp.Persistence.Context;
using SocialApp.Persistence.Repositories;

namespace SocialApp.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();  //tek satırda return varsa bu yapıda kullanabilirim

        public int Save() => dbContext.SaveChanges(); 

        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=> new ReadRepository<T>(dbContext);
   
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=> new WriteRepository<T>(dbContext);
    }
}