using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MutlShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly GetAdressQueryHandler _getadressqueryHandler;
        private readonly GetAddressByIdQueryHandler _getaddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createaddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateaddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeaddressCommandHandler;

        public AdressesController(GetAdressQueryHandler getAdressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createaddressCommandHandler, UpdateAddressCommandHandler updateaddressCommandHandler, RemoveAddressCommandHandler removeaddressCommandHandler)
        {
            _getadressqueryHandler = getAdressQueryHandler;
            _getaddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createaddressCommandHandler = createaddressCommandHandler;
            _updateaddressCommandHandler = updateaddressCommandHandler;
            _removeaddressCommandHandler = removeaddressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values =await  _getadressqueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var values = await _getaddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createaddressCommandHandler.Handle(command);
            return Ok("Added successfully");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAdressCommand command)
        {
            await _updateaddressCommandHandler.Handle(command);
            return Ok("Updated successfully");

        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeaddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Removed successfully");

        }


    }
}
