using System.ComponentModel.DataAnnotations;

namespace HelloESDC.API.Models
{
    public class Greeting
    {
        [Key]
        public string Name { get; set; }

        public string Message { get; set; }
    }
}