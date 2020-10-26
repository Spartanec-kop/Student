﻿using Microsoft.IdentityModel.Tokens;
using StudentData.Infrastructure.Business.Security;
using StudentData.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentData.Infrastructure.Business
{
    public class TokenService : ITokenService
    {
        public string Generate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromDays(AuthOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }


        public ClaimsPrincipal DecodeToken(string jwt)
        {
            var validationParameters = AuthOptions.GetTokenParameters();

            try
            {
                var claimsPrincipal = new JwtSecurityTokenHandler()
                    .ValidateToken(jwt, validationParameters, out var _);

                return claimsPrincipal;
            }
            catch (SecurityTokenValidationException stvex)
            {
                // The token failed validation!
                return null;
            }
            catch (ArgumentException argex)
            {
                // The token was not well-formed or was invalid for some other reason.
                return null;
            }
        }
    }
}