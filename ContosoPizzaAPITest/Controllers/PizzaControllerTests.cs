using ContosoPizza.Controllers;
using ContosoPizza.Services;
using ContosoPizza.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Repositories;

namespace ContosoPizza.PizzaControllerTests;

public class PizzaControllerTests
{
	private PizzaController _controller;
	private PizzaService _service;
	private List<Pizza> _mockPizzaList = [ 
		new Pizza { Id = 1, Name = "Cheeze", Price = 12.0f, IsGlutenFree = false },
		new Pizza { Id = 2, Name = "Veggeez", Price = 10.0f, IsGlutenFree = true }
	];

	public PizzaControllerTests()
	{
		Mock<IPizzaRepository> _mockRepository = new Mock<IPizzaRepository>();
			
		_mockRepository	
			.Setup(repository => repository.GetAll())
			.Returns(_mockPizzaList);
		
		_service = new PizzaService(_mockRepository.Object);
		_controller = new PizzaController(_service);
	}

	[Fact]
	public void GetAll_ShouldReturnAllPizzas()
	{
		ActionResult<List<Pizza>> result = _controller.GetAll();

		Assert.IsType<ActionResult<List<Pizza>>>(result);
		Assert.Equal(2, result.Value!.Count);
	}
} 