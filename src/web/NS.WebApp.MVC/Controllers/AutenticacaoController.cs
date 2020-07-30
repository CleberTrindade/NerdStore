using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using NS.WebApp.MVC.Models.Usuario;
using NS.WebApp.MVC.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Controllers
{
	public class AutenticacaoController : MainController
	{
		private readonly IAutenticacaoService _autenticacaoService;
		public AutenticacaoController(IAutenticacaoService autenticacaoService)
		{
			_autenticacaoService = autenticacaoService;
		}

		[HttpGet]
		[Route("nova-conta")]
		public IActionResult Registro()
		{
			return View();
		}

		[HttpPost]
		[Route("nova-conta")]
		public async Task<IActionResult> Registro(UsuarioRegistroViewModel usuarioRegistro)
		{
			if (!ModelState.IsValid) return View(usuarioRegistro);

			var resposta = await _autenticacaoService.Registro(usuarioRegistro);

			if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioRegistro);

			await RealizarLogin(resposta);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[Route("login")]
		public IActionResult Login(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login(UsuarioLoginViewModel usuarioLogin, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;

			if (!ModelState.IsValid) return View(usuarioLogin);

			var resposta = await _autenticacaoService.Login(usuarioLogin);

			if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioLogin);

			await RealizarLogin(resposta);

			if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

			return RedirectToAction(returnUrl);
		}

		[HttpGet]
		[Route("sair")]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}

		private async Task RealizarLogin(UsuarioRespostaLoginViewModel resposta)
		{
			var token = ObterTokenFormatado(resposta.AccessToken);

			var claims = new List<Claim>();
			claims.Add(new Claim("JWT", resposta.AccessToken));
			claims.AddRange(token.Claims);

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			var authProperties = new AuthenticationProperties
			{
				ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
				IsPersistent = true
			};

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				authProperties
				);
		}

		private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
		{
			return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
		}
	}
}
