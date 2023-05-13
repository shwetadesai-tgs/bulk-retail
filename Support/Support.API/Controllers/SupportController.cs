using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Support.Core.IServices;
using AutoMapper;
namespace Support.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportServices _supportService;
        private readonly IMapper _mapper;
        public SupportController(ISupportServices supportServices,
            IMapper mapper)
        {
            _supportService = supportServices;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllSupports")]
        public async Task<IActionResult> GetAll()
        {
            var supports = await _supportService.GetAllSupportsAsync();
            if (supports == null)
                return NotFound();

            return Ok(supports);
        }

    }
}
