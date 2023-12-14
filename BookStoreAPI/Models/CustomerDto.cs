using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models;

public class CustomerDto
{
    public string Name { get; init; } = default!;

    [MaxLength(25)]
    public string? Email { get; set; }

    internal static void Add(CustomerDto customerDto)
    {
        throw new NotImplementedException();
    }

}
