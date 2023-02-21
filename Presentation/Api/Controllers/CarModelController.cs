using Application.CarModel.GetModels.Contracts;
using Application.GuidRequest;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[Route("carModel")]
[ApiController]
public class CarModelController : ControllerBase
{
    private readonly Lazy<IGetModelsService> _getModelsService;


    public CarModelController(Lazy<IGetModelsService> getModelsService)
    {
        _getModelsService = getModelsService;
    }


    [HttpGet("manufacturer/{Id:guid}")]
    public IActionResult GetModelsOfManufacturer([FromRoute]GuidRequest request)
    {
        var result = _getModelsService.Value.Run(request);

        if (result.IsError)
            return StatusCode(404, result.Description.ToString());

        return Ok(result.Body);
    }
    
}