using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Data.Reponsitories;
using KamikazeChicken.Model.Models;

namespace KamikazeChicken.Service
{
    public interface IContactDetailService
    {
        ContactDetail GetDefaultContact();
    }

    public class ContactDetailService : IContactDetailService
    {
        private IContactDetailRepository _contactDetailRepository;
        private IUnitOfWork _unitOfWork;

        public ContactDetailService(IContactDetailRepository contactDetaiRepository, IUnitOfWork unitOfWork)
        {
            this._contactDetailRepository = contactDetaiRepository;
            this._unitOfWork = unitOfWork;
        }

        public ContactDetail GetDefaultContact()
        {
            return _contactDetailRepository.GetSingleByCondition(x => x.Status);
        }
    }
}