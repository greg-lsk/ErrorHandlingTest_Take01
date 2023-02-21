using Application.Authentication.Login;
using Application.Authentication.Login.Contracts;
using Application.Authentication.Register;
using Application.Authentication.Register.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[Route("auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{

    private readonly Lazy<ILoginService> _loginService;
    private readonly Lazy<IRegisterService> _registerService;


    public AuthenticationController(Lazy<ILoginService> loginService,
                                    Lazy<IRegisterService> registerService)
    {
        _loginService = loginService;
        _registerService = registerService;
    }


    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _registerService.Value.Run(request);

        if (result.IsError)
            return StatusCode(400, result.Description.ToString());

        return Ok(result.Body);
    }

    [HttpGet("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _loginService.Value.Run(request);

        if (result.IsError)
            return StatusCode(400, result.Description.ToString());

        return Ok(result.Body);
    }

}