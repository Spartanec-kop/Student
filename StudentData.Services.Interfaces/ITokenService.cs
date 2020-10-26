using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace StudentData.Services.Interfaces
{
    public interface ITokenService
    {
        string Generate(string userName);

        ClaimsPrincipal DecodeToken(string jwt);
    }
}
