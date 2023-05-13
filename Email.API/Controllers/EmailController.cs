using Mailgun.Messages;
using Mailgun.Service;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

namespace Email.API.Controllers
{
    public class EmailController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            MailService mailService = new MailService();
            await mailService.SendAsync("janki.thakkar@triveniglobalsoft.com",
                "janki.thakkar@triveniglobalsoft.com",
                "Subject", "Message");
            return null;
        }
    }
}
