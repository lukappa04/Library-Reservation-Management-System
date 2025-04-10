using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;

    [Route("api/[controller]")]
    [ApiController]
    [Tags("Customer")]
    public class GetAllCustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public GetAllCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllCustomerAsync();
            return Ok(customers);
        }
    }

