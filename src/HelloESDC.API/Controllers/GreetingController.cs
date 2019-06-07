using System;
using System.Collections.Generic;
using HelloESDC.API.Models;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller that manages the greeting.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GreetingController : ControllerBase
{
    private readonly IGreetingService service;

    /// <summary>
    /// Initializes a new instance of the <see cref="GreetingController"/> class.
    /// </summary>
    /// <param name="service">service reference.</param>
    public GreetingController(IGreetingService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Gets a list of greetings.
    /// </summary>
    /// <returns>greeting items.</returns>
    /// GET api/greeting
    [HttpGet]
    public ActionResult<IEnumerable<Greeting>> Get()
    {
        var items = this.service.GetAllItems();
        return this.Ok(items);
    }

    /// <summary>
    /// Get a greeting by id.
    /// </summary>
    /// <param name="id">Guid id.</param>
    /// <returns>returns a greeting.</returns>
    /// GET api/greeting/5
    [HttpGet("{id}")]
    public ActionResult<Greeting> Get(Guid id)
    {
        var item = this.service.GetById(id);

        if (item == null)
        {
            return this.NotFound();
        }

        return this.Ok(item);
    }

    /// <summary>
    /// Posts a new greeting to the service.
    /// </summary>
    /// <param name="value">The new greeting.</param>
    /// <returns>returns a CreatedAtActionResult.</returns>
    /// POST api/greeting
    [HttpPost]
    public ActionResult Post([FromBody] Greeting value)
    {
        if (!this.ModelState.IsValid)
        {
            return this.BadRequest(this.ModelState);
        }

        var item = this.service.Add(value);
        return this.CreatedAtAction("Get", new { id = item.Id }, item);
    }

    /// <summary>
    /// Removes a greeting.
    /// </summary>
    /// <param name="id">The identifier of the greeting.</param>
    /// <returns>Returns an ok result.</returns>
    /// DELETE api/greeting/5
    [HttpDelete("{id}")]
    public ActionResult Remove(Guid id)
    {
        var existingItem = this.service.GetById(id);

        if (existingItem == null)
        {
            return this.NotFound();
        }

        this.service.Remove(id);
        return this.Ok();
    }
}