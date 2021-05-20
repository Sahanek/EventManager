using System.Threading.Tasks;
using EventManager.DataAccess.CQRS.Queries;

namespace EventManager.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly EventStorageDbContext _context;

        public QueryExecutor(EventStorageDbContext context)
        {
            _context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(_context);
        }
    }
}