using Microsoft.AspNetCore.Mvc;

namespace BulkRetail.PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Summaries);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(Summaries.ToList());
        }
    }
}