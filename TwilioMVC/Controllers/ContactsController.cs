using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwilioMVC.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwilioMVC.Controllers
{
    public class ContactsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(Contact.ContactList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Create(Contact contact)
		{
			const string accountSid = "ACbdad9a7a5b65ad655c501ef37ee0375f";
			const string authToken = "ac924cd3e5aca5f62680c3f4f0e16721";
			TwilioClient.Init(accountSid, authToken);

			var phoneNumber = new PhoneNumber(contact.Number);
			var validationRequest = ValidationRequestResource.Create(
				phoneNumber,
				friendlyName: contact.Name);

            var myValidation = (validationRequest.ValidationCode);


            Contact.ContactList.Add(contact);
            return RedirectToAction("Validation", new { val = myValidation });
		}

        public IActionResult Validation(int val)
        {

            ViewBag.ValNum = val;
            return View();
        }


         

    }
}
