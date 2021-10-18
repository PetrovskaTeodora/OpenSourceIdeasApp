using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public static class CookiesUtils
    {
		private static readonly IAuthenticationService _authenticationService = new AuthenticationService();

		public static string GetCookie(this HttpRequest request, string key) => request.Cookies[key];

		public static void SetCookie(this HttpResponse response, string key, Guid userId)
		{
			CookieOptions option = new CookieOptions();
			option.Expires = DateTime.Now.AddDays(30);
			response.Cookies.Append(key, _authenticationService.GenerateToken(userId), option);
		}
	}
}
