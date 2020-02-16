using MerchandiseManager.Application.Contexts.Authorization.Commands.SignIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class AuthController : BaseController
	{
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> SignIn([FromBody] SignInCommand request)
			=> Ok(await Mediator.Send(request));
	}
}
