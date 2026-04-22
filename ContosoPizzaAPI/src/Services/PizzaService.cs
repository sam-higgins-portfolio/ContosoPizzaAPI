using ContosoPizza.Models;
using ContosoPizza.Repositories;

namespace ContosoPizza.Services;

public class PizzaService
{
    private IPizzaRepository _repository;

    public PizzaService(IPizzaRepository repository)
    {
        _repository = repository;
    }

    public List<Pizza> GetAll() => _repository.GetAll();

    public Pizza? Get(int id) => _repository.GetById(id);

    public void Add(Pizza pizza)
    {
        if (pizza.Id == 0) pizza.Id = _repository.GetNextId();
        _repository.Add(pizza);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public void Update(Pizza pizza)
    {
        _repository.Update(pizza);
    }
}