using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : EntityBase
    {
        private readonly SimpleTradeDbContextFactory _dbContextFactory;

        public NonQueryDataService(SimpleTradeDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using var ctx = _dbContextFactory.CreateDbContext();
            var createdEntity = await ctx.Set<T>().AddAsync(entity);
            await ctx.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            using var ctx = _dbContextFactory.CreateDbContext();
            entity.Id = id;
            ctx.Set<T>().Update(entity);
            await ctx.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();
            var e = await ctx.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            ctx.Set<T>().Remove(e);

            await ctx.SaveChangesAsync();

            return true;
        }
    }
}
