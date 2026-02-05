using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;

        public CargoDetailController(ICargoDetailService CargoDetailService)
        {
            _CargoDetailService = CargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _CargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetaildto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetaildto.Barcode,
                SenderCustomer = createCargoDetaildto.SenderCustomer,
                ReceiverCustomer = createCargoDetaildto.ReceiverCustomer,
                CargoCompanyId = createCargoDetaildto.CargoCompanyId,
                
            };

            _CargoDetailService.TInsert(CargoDetail);
            return Ok("Cargo company added successfully!");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Cargo removed successfully");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _CargoDetailService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
            };
            _CargoDetailService.TUpdate(CargoDetail);
            return Ok("Cargo company updated succesfully");
        }
    }
}
