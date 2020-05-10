using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly SimpleTradeDbContextFactory _dbContextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(SimpleTradeDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(dbContextFactory);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Accounts
                .Include(c => c.AccountHolder)
                .Include(c => c.AssetTransactions).ToListAsync();
        }

        public async Task<Account> Get(int id)
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            return await ctx.Accounts
                .Include(c => c.AccountHolder)
                .Include(c => c.AssetTransactions).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> GetByUserName(string username)
        {
            using var ctx = _dbContextFactory.CreateDbContext();
            var account = await ctx.Accounts.Include(c => c.AccountHolder).FirstOrDefaultAsync(r => r.AccountHolder.UserName == username);

            return account;
        }

        public async Task<Account> GetByEmail(string email)
        {
            using var ctx = _dbContextFactory.CreateDbContext();
            var account = await ctx.Accounts.Include(x => x.AccountHolder).FirstOrDefaultAsync(r => r.AccountHolder.Email == email);

            return account;
        }
    }
}
