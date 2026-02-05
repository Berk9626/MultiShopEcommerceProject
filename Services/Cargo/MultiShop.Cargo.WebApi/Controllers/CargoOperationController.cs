using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;

        public CargoOperationController(ICargoOperationService CargoOperationService)
        {
            _CargoOperationService = CargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _CargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationdto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationdto.Barcode,
                Description = createCargoOperationdto.Description,
                OperationDate = createCargoOperationdto.OperationDate,
            };

            _CargoOperationService.TInsert(CargoOperation);
            return Ok("Cargo company added successfully!");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _CargoOperationService.TDelete(id);
            return Ok("Cargo removed successfully");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _CargoOperationService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,

            };
            _CargoOperationService.TUpdate(CargoOperation);
            return Ok("Cargo company updated succesfully");
        }
    }
}
