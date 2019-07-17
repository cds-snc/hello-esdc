using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloESDC.API.Database;
using HelloESDC.API.Models;

namespace HelloESDC.API.Services
{
    /// <summary>
    /// Implmentation of the Greeting interface.
    /// </summary>
    public class GreetingService : IGreetingService
    {
        private readonly HelloESDCContext context;

        /// <summary>
        ///  Initializes a new instance of the <see cref="GreetingService"/> class.
        /// </summary>
        /// <param name="helloContext">The database reference.</param>
        public GreetingService(HelloESDCContext helloContext)
        {
            this.context = helloContext;

            if (this.context.Greetings.Count() == 0)
            {
                this.context.Greetings.Add(new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Hello in English",
                    Message = "Hello World!",
                });
                this.context.Greetings.Add(new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Bonjour en français",
                    Message = "Bonjour le monde!",
                });
                this.context.SaveChanges();
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
        /// Get a greeting by identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns>Returns a greeting.</returns>
        public Greeting GetById(Guid id)
        {
            return this.context.Greetings.Find(id);
        }

        public Greeting GetRandom()
        {
            var random = new Random();
            var greetings = this.GetAllItems();
            int index = random.Next(greetings.Count);

            return greetings[index];
        }
    }
}
