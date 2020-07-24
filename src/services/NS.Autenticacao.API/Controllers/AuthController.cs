﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NS.Autenticacao.API.Extensions;
using NS.Autenticacao.API.Models.Usuario;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NS.Autenticacao.API.Controllers
{
	[ApiController]
	[Route("api/autenticacao")]
	public class AuthController : Controller
	{

		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly AppSettings _appSettings;

		public AuthController(SignInManager<IdentityUser> signInManager, 
							  UserManager<IdentityUser> userManager,
							  IOptions<AppSettings> appSettings)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_appSettings = appSettings.Value;
		}

		[HttpPost("nova-conta")]
		public async Task<ActionResult> Registrar(UsuarioRegistroViewModel usuarioRegistro)
		{
			if (!ModelState.IsValid) return BadRequest();

			var user = new IdentityUser
			{
				UserName = usuarioRegistro.Email,
				Email = usuarioRegistro.Email,
				EmailConfirmed = true
			};

			var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

			if (result.Succeeded)
			{
				await _signInManager.SignInAsync(user, false);
				return Ok(await GerarJwt(usuarioRegistro.Email));
			}

			return BadRequest();

		}

		[HttpPost("login")]
		public async Task<ActionResult> Login(UsuarioLoginViewModel usuarioLogin)
		{
			if (!ModelState.IsValid) return BadRequest();

			var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);

			if (result.Succeeded)
			{
				return Ok(await GerarJwt(usuarioLogin.Email));
			}

			return BadRequest();

		}

		private async Task<UsuarioRespostaLoginViewModel> GerarJwt(string email)
		{

			var user = await _userManager.FindByEmailAsync(email);
			var claims = await _userManager.GetClaimsAsync(user);
			var userRoles = await _userManager.GetRolesAsync(user);

			claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
			claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
			claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
			claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochData(DateTime.UtcNow).ToString()));
			claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochData(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

			foreach (var userRole in userRoles)
			{
				claims.Add(new Claim("role", userRole));
			}

			var identityClaims = new ClaimsIdentity();
			identityClaims.AddClaims(claims);

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

			var token = tokenHandler.CreateToken(new SecurityTokenDescriptor { 
				Issuer = _appSettings.Emissor,
				Audience = _appSettings.ValidoEm,
				Subject = identityClaims,
				Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			});

			var encondedToken = tokenHandler.WriteToken(token);

			var response = new UsuarioRespostaLoginViewModel {
				AccessToken = encondedToken,
				ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
				UsuarioToken = new UsuarioToken { 
					Id = user.Id,
					Email = user.Email,
					Claims = claims.Select( c => new UsuarioClaim { Type = c.Type, Value = c.Value} )
				}
			};

			return response;
		}

		private static long ToUnixEpochData(DateTime date)
			=> (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
	}
}