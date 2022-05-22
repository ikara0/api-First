using BilgeAdam.Common.Dtos;
using BilgeAdam.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.Api.MyPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService service;

        public SupplierController(ISupplierService service)
        {
            this.service = service;
        }
        [HttpGet("list")]
        public IActionResult GetPagedSupplier([FromQuery]int count, [FromQuery] int page)
        {
            var result = service.GetPagedSuppliers(count, page);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = service.GetSupplierById(id);
            if(result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Bu Id de veri Bulunamadı!");
            }
        }
        [HttpPost("add")]
        public IActionResult Create([FromBody] SupplierAddDto dto)
        {
            var result = service.AddNewSupplier(dto);
            if (!result)
            {
                return BadRequest("Veri Kaydetme Başarısız!");
            }
            return Ok("Veri Başarıyla Kaydedildi.");
        } 

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSupplier([FromRoute]int id)
        {
            var result = service.DeleteSupplierById(id);
            if (result)
            {
                return Ok("Silme İşlemi Başarılı.");
            }
            else
            {
                return BadRequest("Bu Id de veri bulunamadı!");
            }
        }
    }
}
