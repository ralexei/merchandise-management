using MerchandiseManager.Application.Contexts.Users.Commands.AddNewUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class UsersController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> AddNewUser([FromBody] AddNewUserCommand request)
		{
			await Mediator.Send(request);

			return Ok();
		}
	}
}
