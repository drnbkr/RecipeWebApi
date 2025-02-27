using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Entities.Dtos;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;

namespace Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;
        public AuthenticationManager(ILoggerService logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signinCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;

            if (populateExp)
            {
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            }

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);

            IdentityResult result;
            if (!string.IsNullOrEmpty(userForRegistrationDto.Password))
            {
                // Register with email and password
                result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            }
            else
            {
                // Register with external provider (Google, Apple, Facebook)
                result = await _userManager.CreateAsync(user);
            }

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);
            }

            return result;
        }
        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
        {
            if (!string.IsNullOrEmpty(userForAuthenticationDto.Provider) && !string.IsNullOrEmpty(userForAuthenticationDto.ProviderKey))
            {
                // External login
                _user = await _userManager.FindByLoginAsync(userForAuthenticationDto.Provider, userForAuthenticationDto.ProviderKey);
            }
            else
            {
                // Traditional login
                _user = await _userManager.FindByEmailAsync(userForAuthenticationDto.Email);
            }

            var result = _user != null && (string.IsNullOrEmpty(userForAuthenticationDto.Password) || await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password));

            if (!result)
            {
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            }

            return result;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(ClaimTypes.Email, _user.Email)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signinCredentials
            );

            return tokenOptions;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var email = principal.FindFirst(ClaimTypes.Email)?.Value; 
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new RefreshTokenBadRequestException();
            }

            _user = user;
            return await CreateToken(populateExp: false);
        }

        public async Task<bool> CheckEmail(string email)
        {
            _user = await _userManager.FindByEmailAsync(email);
            var result = _user != null;
            return result;
        }
    }
}