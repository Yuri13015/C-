using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookStoreAPI.Controllers; 


[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{

    private readonly ApplicationDbContext _dbContext; // Contexte de la base de données pour les opérations EF Core.
    private readonly IMapper _mapper; // AutoMapper pour mapper les entités en modèles DTO.


    // Constructeur pour l'injection de dépendance
    public CustomerController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
    {
        var customers = await _dbContext.Customers.ToListAsync(); // Récupère tous les clients

        var customersDto = new List<CustomerDto>(); // Liste pour stocker les DTOs.

        foreach (var customer in customers)
        {
            CustomerDto.Add(_mapper.Map<CustomerDto>(customer)); // Convertit chaque client en DTO
        }


        return Ok(customersDto); // Retourne la liste des clients en tant que DTO

    }
    // POST: api/Book
    // BODY: Book (JSON)
    [Authorize]
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Customer))]
    [ProducesResponseType(400)] // Renvoie une réponse possible en cas d'erreur
    public async Task<ActionResult<Customer>> PostCustomer([FromBody] Customer customer)
    {
        if (customer == null)
        {
            return BadRequest(); // Retourne une erreur si le client est null
        }
        Customer? addedCustomer = await _dbContext.Customers.FirstOrDefaultAsync(b => b.Title == customer.Title);
        if (addedCustomer != null)
        {
            return BadRequest("Le client existe deja");
        }
        else
        {
            await _dbContext.Customers.AddAsync(customer); // Ajoute le client à la base de données
            await _dbContext.SaveChangesAsync(); // Enregistre les changements

            return Created("api/Customer", customer); // Retourne le client créé

        }
    }

    // TODO: Add PUT and DELETE methods
    // PUT: api/Book/5
    // BODY: Book (JSON)
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> PutCustomer(int id, [FromBody] Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest(); // Retourne une erreur si l'ID ne correspond pas
        }
        var customerToUpdate = await _dbContext.Customers.FirstOrDefaultAsync(b => b.Id == id);

        if (customerToUpdate == null)
        {
            return NotFound(); // Retourne une erreur si le client n'est pas trouvé
        }

            // Mise à jour des propriétés du client ici.

        _dbContext.Entry(customerToUpdate).State = EntityState.Modified; // Marque l'entité comme modifiée.
        await _dbContext.SaveChangesAsync(); // Enregistre les changements.
        return NoContent(); // Retourne une réponse sans contenu.
    }

    [HttpPost("validationTest")]
    public ActionResult ValidationTest([FromBody] CustomerDto customer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Customer>> DeleteCustomer(int id)
    {
        var customerToDelete = await _dbContext.Customers.FindAsync(id);

        if (customerToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Customers.Remove(customerToDelete);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

}