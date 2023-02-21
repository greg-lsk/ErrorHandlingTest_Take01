using Microsoft.AspNetCore.Mvc;

using Application.GuidRequest;
using Application.CarOwnership.GetUserCars.Contracts;
using Application.CarOwnership.AddUserCar;
using Application.CarOwnership.AddUserCar.Contracts;


namespace Api.Controllers;

[Route("car")]
[ApiController]
public class CarOwnershipController : ControllerBase
{
    private readonly Lazy<IGetUserCarsService> _getCarService;
    private readonly Lazy<IAddUserCarService> _addCarService;

    public CarOwnershipController(Lazy<IGetUserCarsService> getCarService,
                                  Lazy<IAddUserCarService> addCarService)
    {
        _getCarService = getCarService;
        _addCarService = addCarService;
    }


    [HttpGet("user/{Id:guid}")]
    public IActionResult GetCarsOfUser([FromRoute]GuidRequest request)
    {
        var result = _getCarService.Value.Run(request);

        if (result.IsError)
            return StatusCode(409, result.Description.ToString());

        return Ok(result.Body);
    }

    [HttpPost("user/newCar")]
    public IActionResult AddUserCar(AddUserCarRequest request)
    {
        _addCarService.Value.Run(request);
        return Ok();
    }
    
}