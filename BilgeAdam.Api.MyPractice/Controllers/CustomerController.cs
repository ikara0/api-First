using BilgeAdam.Common.Dtos.Customer;
using BilgeAdam.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.Api.MyPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet("customer-list")]
        public IActionResult GetPagedCustomers([FromQuery] int count, [FromQuery] int page)
        {
            var result = service.GetPagedCustomers(count, page);
            return Ok(result);  
        }
        [HttpGet("get/{id}")]
        public IActionResult GetCustomerById([FromRoute] string id)
        {
            var result = service.GetCustomerById(id);
            if(result == null)
            {
                return BadRequest("İstenilen Veri Bulunamadı");
            }
            return Ok(result);

        }
        [HttpPost("add")]
        public IActionResult AddNewCustomer([FromBody] CustomerAddDto dto)
        {
            var result = service.CreateNewCustomer(dto);
            if (!result)
            {
                return BadRequest("İstenilen Customer Eklenemedi!");
            }
            return Ok("İşlem Başarılı.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            var result = service.RemoveCustomerById(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("İşlem Başarılı.");
        }
        [HttpPost("update")]
        public IActionResult UpdateCustomerById([FromBody] CustomerUpdateDto dto)
        {
            var result = service.UpdateCustomer(dto);
            if (!result)
            {
                return BadRequest("İşlem Gerçekleştirilemedi!");
            }
            return Ok("İşlem Başarılı.");
        }
    }
}
