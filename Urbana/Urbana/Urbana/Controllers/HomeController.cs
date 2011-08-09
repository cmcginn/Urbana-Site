using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Urbana.Models;
namespace Urbana.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View(new ContactModel());
        }
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var m = new System.Net.Mail.MailMessage();
                m.From = new System.Net.Mail.MailAddress("postmaster@information-datasystems.com");
                m.To.Add(new System.Net.Mail.MailAddress("chris.s.mcginn@live.com"));

                m.Subject =  String.Format("Urbana inquiry from {0}", model.Email);
                var builder = new System.Text.StringBuilder();
                builder.AppendLine(String.Format("First Name:{0}", model.FirstName));
                builder.AppendLine(String.Format("Last Name:{0}", model.LastName));
                builder.AppendLine(String.Format("Email:{0}", model.Email));
                builder.AppendLine(String.Format("Company:{0}", model.Company));
                builder.AppendLine(String.Format("Phone:{0}-{1}-{2}", model.PhoneAreaCode,model.PhonePrefix,model.PhoneSuffix));
                builder.AppendLine(String.Format("Comment:{0}", model.Comment));

                var mailClient = new System.Net.Mail.SmtpClient();
                mailClient.UseDefaultCredentials = true;
                mailClient.Send(m);
            
               
                return RedirectToAction("Index");
                
            }
            else
                return View(model);
        }
    }
}
