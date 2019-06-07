using System;
using System.Collections.Generic;
using HelloESDC.API.Models;

/// <summary>
/// The greeting service interface.
/// </summary>
public interface IGreetingService
{
    /// <summary>
    /// Get a list of greetings.
    /// </summary>
    /// <returns>Returns a list of greetings.</returns>
    List<Greeting> GetAllItems();

    /// <summary>
    /// Get a greeting by identifier.
    /// </summary>
    /// <param name="id">The unique identifier.</param>
    /// <returns>Returns a greeting.</returns>
    Greeting GetById(Guid id);
}
