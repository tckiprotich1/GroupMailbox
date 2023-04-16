using GroupMailbox.Models;
using Microsoft.AspNetCore.Mvc;
using GroupMailbox.Services;

namespace GroupMailbox.Controllers;

[ApiController]
[Route("[controller]")]

public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // Get all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return PizzaService.GetAll();
    }

    // get by id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if(pizza is null) return NotFound();
        return pizza;
    }

    // create action
    [HttpPost]
    public ActionResult<Pizza> Add(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Add), new { id = pizza.Id }, pizza);
    }

    // update action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if(id != pizza.Id) return BadRequest();
        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null) return NotFound();
        PizzaService.Update(pizza);
        return NoContent();
    }

    // delete action
    [HttpDelete("{id}")]
    public ActionResult<Pizza> Delete(int id)
    {
        var pizza = PizzaService.Get(id);
        if(pizza is null) return NotFound();
        PizzaService.Delete(id);
        return pizza;
    }


}