using MovieAPI.Data;

namespace MovieAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public MovieRepository MovieRepository => new (_dataContext);
        public UserRepository UserRepository => new (_dataContext);
        public OrderRepository OrderRepository => new (_dataContext);

        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
