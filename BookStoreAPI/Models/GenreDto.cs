using System;
using System.ComponentModel.DataAnnotations;

public class GenreDto
{
    public int Id { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    internal static void Add(GenreDto genreDto)
    {
        throw new NotImplementedException();
    }

}
