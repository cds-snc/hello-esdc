using System;
using System.Collections.Generic;

public interface IGreetingService
{
    List<GreetingItem> GetAllItems();
    GreetingItem Add(GreetingItem item);
    GreetingItem GetById(Guid id);
    void Remove(Guid id);
}
