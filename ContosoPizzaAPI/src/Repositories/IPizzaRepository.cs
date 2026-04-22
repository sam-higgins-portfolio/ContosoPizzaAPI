using ContosoPizza.Models;

namespace ContosoPizza.Repositories;

public interface IPizzaRepository
{
	List<Pizza> GetAll();
	Pizza? GetById(int id);
	int GetNextId();
	void Add(Pizza pizza);
	void Update(Pizza pizza);
	void Delete(int id);
}