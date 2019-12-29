using AutoMapper;
using MerchandiseManager.Application.Contexts.Users.Commands.AddNewUser;
using MerchandiseManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Users
{
	public class UserMapperProfile : Profile
	{
		public UserMapperProfile()
		{
			CreateMap<AddNewUserCommand, User>()
				.ForMember(m => m.Password, opt => opt.Ignore());
		}
	}
}
