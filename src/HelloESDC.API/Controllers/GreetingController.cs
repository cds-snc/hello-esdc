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
    /// Get a random greeting.
    /// </summary>
    /// <returns>returns a greeting.</returns>
    /// GET api/greeting/random
    [HttpGet("random")]
    public ActionResult<Greeting> Random()
    {
        var item = this.service.GetRandom();

        if (item == null)
        {
            return this.NotFound();
        }

        return this.Ok(item);
    }
}