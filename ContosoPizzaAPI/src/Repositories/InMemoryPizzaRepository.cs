using ContosoPizza.Models;

namespace ContosoPizza.Repositories;

public class InMemoryPizzaRepository : IPizzaRepository
{
	private List<Pizza> _pizzas;
	private int _nextId;

	public InMemoryPizzaRepository()
	{
		_pizzas =[
			new Pizza { Id = 1, Name = "Cheeze", Price = 12.0f, IsGlutenFree = false },
			new Pizza { Id = 2, Name = "Veggeez", Price = 10.0f, IsGlutenFree = true }
		];

		_nextId = 3;
	}

	public void Add(Pizza pizza)
	{
		_pizzas.Add(pizza);
		_nextId++;
	}

	public void Delete(int id)
	{
		Pizza? pizza = GetById(id);

		if (pizza is null) return;

		_pizzas.Remove(pizza);	}

	public List<Pizza> GetAll()
	{
		return _pizzas.ToList();
	}

	public Pizza? GetById(int id)
	{
		return _pizzas.FirstOrDefault(p => p.Id == id);
	}

	public int GetNextId()
	{
		return _nextId;
	}

	public void Update(Pizza pizza)
	{
		int index = _pizzas.FindIndex(p => p.Id == pizza.Id);

		if (index == -1) return;

		_pizzas[index] = pizza;
	}
}
