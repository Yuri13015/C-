using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BookStoreAPI.Controllers; // BookStoreAPI est l'espace de nom racine de mon projet 



// Ceci est une annotation, elle permet de définir des métadonnées sur une classe
// Dans ce contexte elle permet de définir que la classe BookController est un contrôleur d'API
// On parle aussi de decorator / décorateur

//Cette classe BookController est le contrôleur d'API qui gère les requêtes relatives aux livres.

[ApiController]
public class BookController : ControllerBase
{

    //Cette annotation [HttpGet("books")] indique que cette méthode répond aux requêtes GET avec l'URL /books. Elle renvoie une ActionResult<List<Book>>, ce qui signifie que la méthode peut renvoyer différents types de résultats, tels que Ok(), NotFound(), etc. Dans ce cas, la méthode renvoie une liste de livres.
    [HttpGet("books")]
    public ActionResult<List<Book>> GetBooks()
    {

        //Dans cette méthode, nous créons une liste de livres avec un seul livre. La liste est ensuite renvoyée en utilisant Ok(), qui renvoie un code de statut HTTP 200 OK avec la liste de livres comme corps de la réponse.

        var books = new List<Book>
        {
            new() { Id = 1, Title = "Le seigneur des anneaux", Author = "J.R.R Tolkien" }
        };

        return Ok(books);

    }
}