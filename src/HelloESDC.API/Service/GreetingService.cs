using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloESDC.API.Database;
using HelloESDC.API.Models;

namespace HelloESDC.API.Service
{
    /// <summary>
    /// Implmentation of the Greeting interface.
    /// </summary>
    public class GreetingService : IGreetingService
    {
        private readonly List<Greeting> greetingList = null;

        private readonly HelloESDCContext context;

        /// <summary>
        ///  Initializes a new instance of the <see cref="GreetingService"/> class.
        /// </summary>
        public GreetingService(HelloESDCContext _context)
        {
            this.context = _context;

            if (_context.Greetings.Count() == 0)
            {
                _context.Greetings.Add(new Greeting {
                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Orange Juice", 
                    Message = "Message 1",
                });
                _context.Greetings.Add(new Greeting {
                    Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Dairy Milk", 
                    Message = "Message 2",
                });
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Get a list of greetings.
        /// </summary>
        /// <returns>Returns a list of greetings.</returns>
        public List<Greeting> GetAllItems()
        {
            return this.context.Greetings.ToList();
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
