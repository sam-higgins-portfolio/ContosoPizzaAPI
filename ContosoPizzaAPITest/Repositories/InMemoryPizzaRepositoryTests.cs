using ContosoPizza.Models;
using ContosoPizza.Repositories;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace ContosoPizza.PizzaServiceTests;

public class InMemoryPizzaRepositoryTests
{
	private InMemoryPizzaRepository _repository;

	public InMemoryPizzaRepositoryTests()
	{
		_repository = new InMemoryPizzaRepository();

	}

	[Fact]
	public void GetNextId_ShouldReturnNextId()
	{
		int result = _repository.GetNextId();

		Assert.Equal(3, result);
	}

	[Fact]
	public void GetAll_ShouldReturnAllPizzas()
	{
		List<Pizza> result = _repository.GetAll();

		Assert.Equal(2, result.Count);
	}

	[Fact]
	public void GetById_ShouldReturnCorrectPizza()
	{
		Pizza? result = _repository.GetById(2);

		Assert.NotNull(result);
		Assert.Equal("Veggeez", result!.Name);
	}

	[Fact]
	public void Add_ShouldAddPizzaAndAdvanceNextId()
	{
		Pizza newPizza = new Pizza { Name = "Meateez", Price = 15.0f, IsGlutenFree = false};

		_repository.Add(newPizza);

		List<Pizza> result = _repository.GetAll();

		Assert.Equal(3, result.Count);
		Assert.Equal(4, _repository.GetNextId());
	}

	[Fact]
	public void Delete_ShouldRemovePizza()
	{
		_repository.Delete(2);

		List<Pizza> result = _repository.GetAll();

		Assert.Single(result);
		Assert.Equal(1, result.First().Id);
	}

	[Fact]
	public void Update_ShouldUpdatePizza()
	{
		Pizza updatedPizza = new Pizza { Id = 1, Name = "Cheeze", Price = 13.0f, IsGlutenFree = false };

		_repository.Update(updatedPizza);

		Pizza? result = _repository.GetById(1);

		Assert.NotNull(result);
		Assert.Equal(13.0f, result!.Price);
	}
}