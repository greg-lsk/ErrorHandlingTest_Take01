﻿namespace Application.Authentication.Common.Responce;

public interface IAuthenticationResponce
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}