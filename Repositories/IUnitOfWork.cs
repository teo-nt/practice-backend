namespace MovieAPI.Repositories
{
    public interface IUnitOfWork
    {
        public MovieRepository MovieRepository { get;}
        public UserRepository UserRepository { get;}
        public OrderRepository OrderRepository { get; }

        Task<bool> SaveAsync();
    }
}
