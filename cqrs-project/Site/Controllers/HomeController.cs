using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}