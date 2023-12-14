
using System.Collections.Generic;

namespace BookStoreAPI.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public required string Title { get; init; }
        public required ICollection<Book> Books { get; set; }


    }
}
