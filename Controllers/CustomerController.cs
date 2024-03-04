using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CLOUDNA.Repository.Contracts;
using System.Data.SqlClient;
using CLOUDNA.Entities;

namespace CLOUDNA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer custRepo;
        public CustomerController(ICustomer custRepository)
        {
            custRepo = custRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await custRepo.GetCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {                
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("GetRecentDeliveryDetails")]
        public async Task<IActionResult> GetRecentDeliveryDetails([FromBody] YourRequestModel requestData)
        {
            try
            {
                if (requestData == null)
                {
                    return BadRequest("Invalid request data");
                }
                string userMail = requestData.user;
                string customerId = requestData.customerId;

                var isValidcustomer = await custRepo.GetCustomer(customerId, userMail);
                if(isValidcustomer == null)
                {
                    return BadRequest("Invalid request data");
                }

                var customer = await custRepo.GetDeliveryDetailsOfRecentOrder(userMail, customerId);
                if (customer == null)
                    return NotFound();
                return Ok(customer);
            }
            catch (Exception ex)
            {               
                return StatusCode(500, ex.Message);
            }
        }
        // public async Task<IActionResult> GetRecentDeliveryDetails([FromBody] dynamic requestData)
        public class YourRequestModel
        {
            public string user { get; set; }
            public string customerId { get; set; }
        }

    }
}
