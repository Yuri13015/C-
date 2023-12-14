
using System.Collections.Generic;

namespace BookStoreAPI.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public required string Title { get; init; }


        public required ICollection<Book> Books { get; set; } // Propriété Books de type ICollection<Book>. Elle représente la collection de livres publiés par cet éditeur.

    }
}
