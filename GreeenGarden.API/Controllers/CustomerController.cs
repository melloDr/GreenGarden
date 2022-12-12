using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GreeenGarden.Business;
using GreeenGarden.Business.Interface;
using GreeenGarden.Business.Model;
using GreeenGarden.Business.Model.CustomerModel;
using Microsoft.AspNetCore.Authorization;
using GreeenGarden.Business.Service;

namespace GreeenGarden.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> getAll()
        {
            var result = await _service.getAll();
            if (result.IsSuccess && result.Code == 200) return Ok(result);
            return BadRequest(result);
        }


        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultModel))]
        [HttpPost]
        public async Task<IActionResult> createCustomer( IFormFile imageFile, [FromForm] CustomerResponeToCreate model)
        {
            var result = await _service.createCustomer(model, imageFile);

            if (result.IsSuccess && result.Code == 200) return Ok(result);
            return BadRequest(result);
        }



        [HttpGet("CheckToken")]
        public async Task<IActionResult> checkToken()
        {
            var token = (Request.Headers)["Authorization"].ToString().Split(" ")[1];

            //var result = await _service.checkToken(token);
            var result = HttpContext.User.FindFirst("userId");

            return Ok(result);
        }


    }
}
