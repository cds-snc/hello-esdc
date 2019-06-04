using System;
using System.ComponentModel.DataAnnotations;

public class GreetingItem
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Message { get; set; }
}
