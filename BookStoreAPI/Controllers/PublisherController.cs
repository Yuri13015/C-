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
public class PublisherController : ControllerBase
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;


    public PublisherController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<GenreDto>>> GetGenres()
    {
        var publishers = await _dbContext.Publishers.ToListAsync();

        var genresDto = new List<GenreDto>();

        foreach (var publisher in publishers)
        {
            GenreDto.Add(_mapper.Map<GenreDto>(publisher));
        }


        return Ok(genresDto);

    }
    // POST: api/Book
    // BODY: Book (JSON)
    [Authorize]
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Publisher))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Publisher>> PostGenre([FromBody] Publisher publisher)
    {
        if (publisher == null)
        {
            return BadRequest();
        }
        Publisher? addedGenre = await _dbContext.Publishers.FirstOrDefaultAsync(b => b.Title == publisher.Title);
        if (addedGenre != null)
        {
            return BadRequest("L'editeur existe deja");
        }
        else
        {
            await _dbContext.Publishers.AddAsync(publisher);
            await _dbContext.SaveChangesAsync();

            return Created("api/Publisher", publisher);

        }
    }

    // TODO: Add PUT and DELETE methods
    // PUT: api/Book/5
    // BODY: Book (JSON)
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> PutGenre(int id, [FromBody] Publisher publisher)
    {
        if (id != publisher.Id)
        {
            return BadRequest();
        }
        var genreToUpdate = await _dbContext.Publishers.FirstOrDefaultAsync(b => b.Id == id);

        if (genreToUpdate == null)
        {
            return NotFound();
        }


        _dbContext.Entry(genreToUpdate).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("validationTest")]
    public ActionResult ValidationTest([FromBody] GenreDto publisher)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Publisher>> DeleteGenre(int id)
    {
        var genreToDelete = await _dbContext.Publishers.FindAsync(id);

        if (genreToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Publishers.Remove(genreToDelete);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

}