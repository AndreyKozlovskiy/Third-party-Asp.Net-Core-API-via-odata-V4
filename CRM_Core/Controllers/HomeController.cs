using System.Threading.Tasks;
using CRM_Core.Models;
using CRM_Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Core.Controllers
{
    public class HomeController : Controller
    {
        private CreatioService creatioService;

        public HomeController()
        {
            creatioService = new CreatioService("https://cto-creatio.beesender.com", "Supervisor", "Supervisor");
            creatioService.TryLogin();
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = creatioService.GetContacts();
            return View(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string id)
        {
            creatioService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactViewModel contact)
        {
            creatioService.AddContact(contact);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Contact(string id)
        {
            var contact = creatioService.GetContact(id);

            return View(contact);
        }

        [HttpPost]
        public async Task<ActionResult> Contact(ContactViewModel contact)
        {
            creatioService.ChangeConctact(contact);
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
