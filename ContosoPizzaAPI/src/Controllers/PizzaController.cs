using System.ComponentModel;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private PizzaService _service;

    public PizzaController()
    {
        _service = new PizzaService();
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return _service.GetAll();
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        Pizza? pizza = _service.Get(id);

        if(pizza is null)
        {
            return NotFound();
        }

        return pizza;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        _service.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Put(int id, Pizza pizza)
    {
        if (id != pizza.Id) return BadRequest();
        
        if (_service.Get(id) is null) return NotFound();

        _service.Update(pizza);
        
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_service.Get(id) is null) return NotFound();

        _service.Delete(id);

        return NoContent();
    }
}