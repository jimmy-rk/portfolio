using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;

namespace Portfolio_Jimmy.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public void OnPost(string name, string email, string message)
        {
            string messageBody = "Name: " + name + "  Email: " + email + "  Message: " + message;
            var messageDetails = new MimeMessage();
            messageDetails.From.Add(new MailboxAddress("jimmyrk.job@gmail.com"));
            messageDetails.To.Add(new MailboxAddress("jimmyrk.job@gmail.com"));
            messageDetails.Body = new TextPart("plain")
            {
                Text =messageBody
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("jimmyrk.job@gmail.com", "matum309");
                client.Send(messageDetails);
                client.Disconnect(true);
            }
        }
    }
}
