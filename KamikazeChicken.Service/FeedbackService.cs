using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Data.Reponsitories;
using KamikazeChicken.Model.Models;

namespace KamikazeChicken.Service
{
    public interface IFeedbackService
    {
        Feedback Create(Feedback feedback);

        void Save();
    }

    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        private IUnitOfWork _unitOfWork;

        public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork uniOfWork)
        {
            _feedbackRepository = feedbackRepository;
            _unitOfWork = uniOfWork;
        }

        public Feedback Create(Feedback feedback)
        {
            return _feedbackRepository.Add(feedback);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}