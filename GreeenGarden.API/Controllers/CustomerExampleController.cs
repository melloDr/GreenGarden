using GreeenGarden.Business.Model;
using GreeenGarden.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreeenGarden.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerExampleController : ControllerBase
    {
        private readonly ICustomerExample _service;
        public CustomerExampleController(ICustomerExample service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> test()
        {
            var result = new ResultModel();
            result = await _service.test();
            return Ok(result);
        }
    }
}
