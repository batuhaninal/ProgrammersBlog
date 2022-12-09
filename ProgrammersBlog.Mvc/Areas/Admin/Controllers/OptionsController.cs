using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Helpers.Abstract;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OptionsController : Controller
    {
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;
        private readonly IToastNotification _toastNotification;
        private readonly WebsiteInfo _websiteInfo;
        private readonly IWritableOptions<WebsiteInfo> _websiteInfoWriter;
        private readonly SmtpSettings _smtpSettings;
        private readonly IWritableOptions<SmtpSettings> _smtpSettingsWriter;

        public OptionsController(IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter, IToastNotification toastNotification, IOptionsSnapshot<WebsiteInfo> websiteInfo, IWritableOptions<WebsiteInfo> websiteInfoWriter, IOptionsSnapshot<SmtpSettings> smtpSettings, IWritableOptions<SmtpSettings> smtpSettingsWriter)
        {
            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
            _toastNotification = toastNotification;
            _websiteInfo = websiteInfo.Value;
            _websiteInfoWriter = websiteInfoWriter;
            _smtpSettings = smtpSettings.Value;
            _smtpSettingsWriter = smtpSettingsWriter;
        }

        [HttpGet]
        public IActionResult About()
        {
            return View(_aboutUsPageInfo);
        }

        [HttpPost]
        public IActionResult About(AboutUsPageInfo model)
        {
            if (ModelState.IsValid)
            {
                _aboutUsPageInfoWriter.Update(x =>
                {
                    x.Header = model.Header;
                    x.Content = model.Content;
                    x.SeoAuthor = model.SeoAuthor;
                    x.SeoDescription = model.SeoDescription;
                    x.SeoTags = model.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Hakkımızda sayfa içerikleri başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem"
                });
                return View(model);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult GeneralSettings()
        {
            return View(_websiteInfo);
        }

        [HttpPost]
        public IActionResult GeneralSettings(WebsiteInfo model)
        {
            if (ModelState.IsValid)
            {
                _websiteInfoWriter.Update(x =>
                {
                    x.Title = model.Title;
                    x.MenuTitle = model.MenuTitle;
                    x.SeoAuthor = model.SeoAuthor;
                    x.SeoDescription = model.SeoDescription;
                    x.SeoTags = model.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Sitenizin genel ayarlari başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem"
                });
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EmailSettings()
        {
            return View(_smtpSettings);
        }

        [HttpPost]
        public IActionResult EmailSettings(SmtpSettings model)
        {
            if (ModelState.IsValid)
            {
                _smtpSettingsWriter.Update(x =>
                {
                    x.Server = model.Server;
                    x.Port = model.Port;
                    x.SenderName = model.SenderName;
                    x.SenderEmail = model.SenderEmail;
                    x.Username = model.Username;
                    x.Password = model.Password;
                });
                _toastNotification.AddSuccessToastMessage("Sitenizin e-posta ayarlari başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem"
                });
                return View(model);
            }
            return View(model);
        }
    }
}
