using MovieAPI.Repositories;

namespace MovieAPI.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MovieService MovieService => new(_unitOfWork);
        public UserService UserService => new(_unitOfWork);
        public OrderService OrderService => new(_unitOfWork);
    }
}
