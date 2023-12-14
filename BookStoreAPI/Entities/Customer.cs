
using System;

namespace BookStoreAPI.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public required string Title { get; init; }

    }
}
