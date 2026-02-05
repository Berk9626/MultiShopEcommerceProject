using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _CargoCustomerService;

        public CargoCustomerController(ICargoCustomerService CargoCustomerService)
        {
            _CargoCustomerService = CargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _CargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerdto)
        {
            CargoCustomer CargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerdto.Address,
                City = createCargoCustomerdto.City,
                District = createCargoCustomerdto.District,
                Email = createCargoCustomerdto.Email,
                Name = createCargoCustomerdto.Name,
                Phone = createCargoCustomerdto.Phone,
                Surname = createCargoCustomerdto.Surname,
                

                
            };

            _CargoCustomerService.TInsert(CargoCustomer);
            return Ok("Cargo  customer added successfully!");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _CargoCustomerService.TDelete(id);
            return Ok("Cargo customer removed successfully");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _CargoCustomerService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer CargoCustomer = new CargoCustomer()
            {
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                Surname = updateCargoCustomerDto.Surname,
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                


            };
            _CargoCustomerService.TUpdate(CargoCustomer);
            return Ok("Cargo customer updated succesfully");
        }
    }
}
