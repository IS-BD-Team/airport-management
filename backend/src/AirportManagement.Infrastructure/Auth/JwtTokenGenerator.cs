using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AirportManagement.Application.Common.Interfaces.Auth;
using AirportManagement.Application.Common.Services;
using AirportManagement.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AirportManagement.Infrastructure.Auth;

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    : IJwtTokengenerator
{
    private readonly JwtSettings _jwtOptions = jwtOptions.Value;

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.Secret)),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.Lastname),
            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
        };

        var securityToken = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            expires: dateTimeProvider.UtcNow.AddMinutes(_jwtOptions.ExpireMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}