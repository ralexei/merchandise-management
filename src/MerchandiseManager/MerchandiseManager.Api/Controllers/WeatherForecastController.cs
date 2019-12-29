﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MerchandiseManager.Application.Contexts.Authorization.Commands;
using MerchandiseManager.Application.Contexts.Authorization.Commands.SignIn;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MerchandiseManager.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IMediator _mediator;
		public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok();
			//var rng = new Random();
			//return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			//{
			//	Date = DateTime.Now.AddDays(index),
			//	TemperatureC = rng.Next(-20, 55),
			//	Summary = Summaries[rng.Next(Summaries.Length)]
			//})
			//.ToArray();
		}

		
	}
}
