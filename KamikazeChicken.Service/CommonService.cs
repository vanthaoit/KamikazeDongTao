using KamikazeChicken.Common;
using KamikazeChicken.Data.Infrastructure;
using KamikazeChicken.Data.Repositories;
using KamikazeChicken.Model.Models;
using System.Collections.Generic;
using System;

namespace KamikazeChicken.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private ISlideRepository _slideRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(ISlideRepository slideRepository,IFooterRepository footerRepository, IUnitOfWork unitOfWork)
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
            _slideRepository = slideRepository;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }
    }
}