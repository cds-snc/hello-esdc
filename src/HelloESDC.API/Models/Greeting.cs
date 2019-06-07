using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloESDC.API.Models
{
    /// <summary>
    /// Greeting class.
    /// </summary>
    public class Greeting
    {
        /// <summary>
        /// Gets or sets the Id property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Name property.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Message property.
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}