using HelloESDC.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class GreetingController : ControllerBase
{
    private readonly IGreetingService _service;

    public GreetingController(IGreetingService service)
    {
        _service = service;
    }

    // GET api/greeting
    [HttpGet]
    public ActionResult<IEnumerable<Greeting>> Get()
    {
        var items = _service.GetAllItems();
        return Ok(items);
    }

    // GET api/greeting/5
    [HttpGet("{id}")]
    public ActionResult<Greeting> Get(Guid id)
    {
        var item = _service.GetById(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    // POST api/greeting
    [HttpPost]
    public ActionResult Post([FromBody] Greeting value)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var item = _service.Add(value);
        return CreatedAtAction("Get", new { id = item.Id }, item);
    }

    // DELETE api/greeting/5
    [HttpDelete("{id}")]
    public ActionResult Remove(Guid id)
    {
        var existingItem = _service.GetById(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        _service.Remove(id);
        return Ok();
    }
}