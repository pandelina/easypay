using System.Diagnostics;
using Contactsbook.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contactsbook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ContactsDbContext _context;

        public HomeController(ILogger<HomeController> logger, ContactsDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Contacts()
        {
            var allContacts = _context.Contacts.ToList();

            return View(allContacts);  
        }

        public IActionResult CreateContacts(int? id)
        {
            if(id != null)
            {
                var contactInDb = _context.Contacts.SingleOrDefault(contact => contact.Id == id);
                return View(contactInDb);
            }

            return View();
        }

        public IActionResult DeleteContacts(int id)
        {
            var contactInDb = _context.Contacts.SingleOrDefault(contact => contact.Id == id);
            _context.Contacts.Remove(contactInDb);
            _context.SaveChanges();
            return RedirectToAction("Contacts");
        }


        public IActionResult CreateContactsForm(Contact model)
        {
            if(model.Id == 0)
            {
                _context.Contacts.Add(model);
            }

            else
            {
                _context.Contacts.Update(model);
            }


            _context.SaveChanges();


            return RedirectToAction("Contacts");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
