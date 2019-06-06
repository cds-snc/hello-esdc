using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloESDC.API.Models;

namespace HelloESDC.API.Service
{
    /// <summary>
    /// Implmentation of the Greeting interface.
    /// </summary>
    public class GreetingService : IGreetingService
    {
        private readonly List<Greeting> greetingList = null;

        /// <summary>
        ///  Initializes a new instance of the <see cref="GreetingService"/> class.
        /// </summary>
        public GreetingService()
        {
            this.greetingList = new List<Greeting>()
            {
                new Greeting()
                {
                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Orange Juice", Message = "Message 1",
                },
                new Greeting()
                {
                    Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Diary Milk", Message = "Message 2",
                },
                new Greeting()
                {
                    Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Frozen Pizza", Message = "Message 3",
                },
            };
        }

        /// <summary>
        /// Get a list of greetings.
        /// </summary>
        /// <returns>Returns a list of greetings.</returns>
        public List<Greeting> GetAllItems()
        {
            return this.greetingList;
        }

        /// <summary>
        /// Adds a greeting.
        /// </summary>
        /// <param name="item">The new greeting.</param>
        /// <returns>Returns a greeting.</returns>
        public Greeting Add(Greeting item)
        {
            item.Id = Guid.NewGuid();
            this.greetingList.Add(item);
            return item;
        }

        /// <summary>
        /// Get a greeting by identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns>Returns a greeting.</returns>
        public Greeting GetById(Guid id)
        {
            return this.greetingList.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        /// <summary>
        /// Removes a greeting.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        public void Remove(Guid id)
        {
            var existing = this.greetingList.First(a => a.Id == id);
            this.greetingList.Remove(existing);
        }
    }
}
