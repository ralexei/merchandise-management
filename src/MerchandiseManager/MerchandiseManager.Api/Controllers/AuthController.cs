using MerchandiseManager.Application.Contexts.Authorization.Commands.SignIn;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class AuthController : BaseController
	{
		public async Task<IActionResult> SignIn([FromBody] SignInCommand request)
			=> Ok(await Mediator.Send(request));
	}
}
