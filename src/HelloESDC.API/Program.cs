using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HelloESDC.API
{
    /// <summary>
    /// Entry class for application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entrypoint for the program.
        /// </summary>
        /// <param name="args">Arguments passed in.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The mechanism that build the web host.
        /// </summary>
        /// <param name="args">Arguments passed in.</param>
        /// <returns>Returns a web host builder. </returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
