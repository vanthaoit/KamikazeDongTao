using BotDetect.Web.Mvc;
using KamikazeChicken.Common;
using KamikazeChicken.Model.Models;
using KamikazeChicken.Service;
using KamikazeChicken.Web.Infrastructure.Extensions;
using KamikazeChicken.Web.Models;
using System.Web.Mvc;

namespace KamikazeChicken.Web.Controllers
{
    public class ContactController : Controller
    {
        private IContactDetailService _contactDetailService;
        private IFeedbackService _feedbackService;

        public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            _contactDetailService = contactDetailService;
            _feedbackService = feedbackService;
        }

        public ActionResult Index()
        {
            FeedbackViewModel feedbackViewModelData = new FeedbackViewModel();
            feedbackViewModelData.ContactDetail = GetDetail();
            return View(feedbackViewModelData);

        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "contactCaptcha", "Mã xác nhận không đúng")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                Feedback newFeedback = new Feedback();
                newFeedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(newFeedback);
                _feedbackService.Save();

                ViewData["SuccessMsg"] = "Gửi phản hồi thành công" ;
                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/template/contact_template.html"));
                content = content.Replace("{{Name}}",feedbackViewModel.Name);
                content = content.Replace("{{Email}}", feedbackViewModel.Email);
                content = content.Replace("{{Message}}", feedbackViewModel.Message);

                var adminEmail = ConfigHelper.GetByKey("AdminEmail");
                MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ website", content);

                feedbackViewModel.Name = "";
                feedbackViewModel.Message = "";
                feedbackViewModel.Email = "";

            }
            feedbackViewModel.ContactDetail = GetDetail();

            return View("Index",feedbackViewModel);
        }
        private ContactDetailViewModel GetDetail()
        {
            var modelData = _contactDetailService.GetDefaultContact();
            var viewModelData = AutoMapper.Mapper.Map<ContactDetail, ContactDetailViewModel>(modelData);
            return viewModelData;
        }
    }
}