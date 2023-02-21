using Application.CarManufacturer.GetManufacturers.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[Route("manufacturer")]
[ApiController]
public class CarManufacturerController : ControllerBase
{
    private readonly Lazy<IGetManufacturersService> _getManufacturersService;


    public CarManufacturerController(Lazy<IGetManufacturersService> getManufacturersService)
    {
        _getManufacturersService = getManufacturersService;
    }


    [HttpGet("all")]
    public IActionResult GetManufacturers()
    {
        var result = _getManufacturersService.Value.Run();

        if (result.IsError)
            return StatusCode(404, result.Description.ToString());

        return Ok(result.Body);
    }

}