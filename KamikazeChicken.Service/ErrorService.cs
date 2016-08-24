using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Data.Reponsitories;
using KamikazeChicken.Model.Models;

namespace KamikazeChicken.Service
{
    public interface IErrorService
    {
        void Create(Error error);

        void Save();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Create(Error error)
        {
            _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}