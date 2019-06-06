using HelloESDC.API.Models;
using System;
using System.Collections.Generic;

public interface IGreetingService
{
    List<Greeting> GetAllItems();
    Greeting Add(Greeting item);
    Greeting GetById(Guid id);
    void Remove(Guid id);
}
