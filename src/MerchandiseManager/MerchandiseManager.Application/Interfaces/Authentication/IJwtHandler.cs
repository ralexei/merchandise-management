using MerchandiseManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Interfaces.Authentication
{
	public interface IJwtHandler
	{
		string GenerateJwt(User user);
	}
}
