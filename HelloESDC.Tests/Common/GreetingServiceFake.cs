using HelloESDC.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloESDC.Tests.Common
{
    public class GreetingServiceFake : IGreetingService
    {
        private readonly List<Greeting> _greeting = null;

        public GreetingServiceFake()
        {
            _greeting = new List<Greeting>()
            {
                new Greeting() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Orange Juice", Message="Message 1" },
                new Greeting() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Diary Milk", Message="Message 2" },
                new Greeting() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Frozen Pizza", Message="Message 3" }
            };
        }

        public List<Greeting> GetAllItems()
        {
            return _greeting;
        }

        public Greeting Add(Greeting newItem)
        {
            newItem.Id = Guid.NewGuid();
            _greeting.Add(newItem);
            return newItem;
        }

        public Greeting GetById(Guid id)
        {
            return _greeting.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            var existing = _greeting.First(a => a.Id == id);
            _greeting.Remove(existing);
        }
    }
}
