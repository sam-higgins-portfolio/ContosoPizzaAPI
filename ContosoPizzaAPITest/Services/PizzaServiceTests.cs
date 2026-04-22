using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.PizzaServiceTests;

public class PizzaServiceTests
{
	private PizzaService _service;

    public PizzaServiceTests()
    {
        _service = new PizzaService();
    }

	[Fact]
	public void GetAll_ShouldReturnAllPizzas()
	{
		List<Pizza> result = _service.GetAll();

		Assert.Equal(2, result.Count);
	}

	[Fact]
	public void Get_ShouldReturnCorrectPizza()
	{
		Pizza? result = _service.Get(2);

		Assert.NotNull(result);
		Assert.Equal("Veggeez", result!.Name);
	}

	[Fact]
	public void Add_ShouldAddPizza()
	{
		Pizza newPizza = new Pizza { Name = "Meateeze", Price = 15.0f, IsGlutenFree = false};

		_service.Add(newPizza);

		List<Pizza> result = _service.GetAll();

		Assert.Equal(3, result.Count);

		Assert.Equal(3, result.Last().Id);
		Assert.Equal("Meateeze", result.Last().Name);
		Assert.Equal(15.0f, result.Last().Price);
		Assert.False(result.Last().IsGlutenFree);
	}

	[Fact]
	public void Delete_ShouldRemovePizza()
	{
		_service.Delete(1);

		List<Pizza> result = _service.GetAll();

		Assert.Single(result);
		Assert.Equal(2, result.First().Id);
	}
}