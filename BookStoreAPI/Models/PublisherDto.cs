using System.ComponentModel.DataAnnotations;

public class PublisherDto
{
    public int Id { get; set; }

    [StringLength(20)]
    public string? Name { get; set; }
}
