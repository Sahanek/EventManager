using System.Threading.Tasks;
using EventManager.DataAccess.CQRS.Commands;

namespace EventManager.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly EventStorageDbContext _context;

        public CommandExecutor(EventStorageDbContext context)
        {
            _context = context;
        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(_context);
        }
    }
}