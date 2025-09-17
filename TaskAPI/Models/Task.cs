using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Models;

public partial class Task
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
}
