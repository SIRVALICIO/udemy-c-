using CleanArchitecture.Application.Constants;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Identity.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;
        private readonly JwtSettings _jwSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager,IOptions< JwtSettings >jwSettings)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _jwSettings = jwSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"El usuario con email {request.Email} no existe");


            }

            var resultado = await _singInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);


            if (!resultado.Succeeded)
            {
                throw new Exception($"Las credenciales son incorrectas");
            };



            var token = await GenerateToken(user);

            var authResponse = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                Username = user.UserName,
            };

            return authResponse;




        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existinguser = await _userManager.FindByEmailAsync(request.Email);
            if (existinguser != null)
            {
                throw new Exception($"El username ya fue tomado por otra cuenta");

            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null)
            {
                throw new Exception($"El email ya fue to mado por otra cuenta");
            }

            var user = new ApplicationUser
            {

                Email = request.Email,
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                UserName = request.Username,
                EmailConfirmed = true
            };

            var token = await GenerateToken(user);
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Operator");
                return new RegistrationResponse
                {
                    Email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = user.Id,
                    Username = user.UserName
                };


            }
            throw new Exception($"{result.Errors}");
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims=await _userManager.GetClaimsAsync(user);
            var roles= await _userManager.GetRolesAsync(user);


            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName) ,
                 new Claim(JwtRegisteredClaimNames.Email, user.Email) ,
                 new Claim(CustomClaimTypes.Uid,user.Id)
            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _jwSettings.Key));
            var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwSettings.Issuer,
                audience: _jwSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwSettings.DurationInMinutes),
                signingCredentials: signInCredentials


                ) ;


            return jwtSecurityToken;




        }
    }
}
