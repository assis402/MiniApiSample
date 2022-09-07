using System.ComponentModel.DataAnnotations;

namespace MiniApiSample.Data;

public class Event
{
    public int Id { get; set; }
    
    [Required]
    public string? Title { get; set; }
    public bool IsCompleted { get; set; }
}