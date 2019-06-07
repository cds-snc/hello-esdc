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
    /// Adds a greeting.
    /// </summary>
    /// <param name="item">The new greeting.</param>
    /// <returns>Returns a greeting.</returns>
    Greeting Add(Greeting item);

    /// <summary>
    /// Get a greeting by identifier.
    /// </summary>
    /// <param name="id">The unique identifier.</param>
    /// <returns>Returns a greeting.</returns>
    Greeting GetById(Guid id);

    /// <summary>
    /// Removes a greeting.
    /// </summary>
    /// <param name="id">The unique identifier.</param>
    void Remove(Guid id);
}
