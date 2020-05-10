using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : EntityBase
    {
        private readonly SimpleTradeDbContextFactory _dbContextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(SimpleTradeDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(dbContextFactory);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }
    }
}
