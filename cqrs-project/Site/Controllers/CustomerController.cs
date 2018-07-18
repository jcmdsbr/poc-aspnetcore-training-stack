using System.Threading.Tasks;
using Application.Domain;
using Application.Repository;
using Domain.Core.Notifications;
using Domain.Entities.Params;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerCommandQueue _commandQueue;
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository customerRepository,
            INotificationHandler<DomainNotification> notifications,
            ICustomerCommandQueue commandQueue)
            : base(notifications)
        {
            _repository = customerRepository;
            _commandQueue = commandQueue;
        }

        public IActionResult Index()
        {
            return View(_repository.List());
        }

        public IActionResult Create()
        {
            return View(new CustomerViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _commandQueue.AddNewCustomerCommand((CustomerParam) model);

            if (IsValidOperation())
            {
                TempData["Success"] = GetMessageSuccess();
                return RedirectToAction("Index");
            }

            TempData["ErrorNotifications"] = GetNotifications();
            return View(model);
        }
    }
}