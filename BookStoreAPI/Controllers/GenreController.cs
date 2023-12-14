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
public class GenreController : ControllerBase
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;


    public GenreController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }



    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<GenreDto>>> GetGenres()
    {
        var genres = await _dbContext.Genres.ToListAsync();

        var genresDto = new List<GenreDto>();

        foreach (var genre in genres)
        {
            GenreDto.Add(_mapper.Map<GenreDto>(genre));
        }


        return Ok(genresDto);

    }
    // POST: api/Book
    // BODY: Book (JSON)
    [Authorize]
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Genre))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Genre>> PostGenre([FromBody] Genre genre)
    {
        if (genre == null)
        {
            return BadRequest();
        }
        Genre? addedGenre = await _dbContext.Genres.FirstOrDefaultAsync(b => b.Title == genre.Title);
        if (addedGenre != null)
        {
            return BadRequest("Le Genre existe deja");
        }
        else
        {
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();

            return Created("api/Genre", genre);

        }
    }

    // TODO: Add PUT and DELETE methods
    // PUT: api/Book/5
    // BODY: Book (JSON)
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> PutGenre(int id, [FromBody] Genre genre)
    {
        if (id != genre.Id)
        {
            return BadRequest();
        }
        var genreToUpdate = await _dbContext.Genres.FirstOrDefaultAsync(b => b.Id == id);

        if (genreToUpdate == null)
        {
            return NotFound();
        }

        // continuez pour les autres propriétés

        _dbContext.Entry(genreToUpdate).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("validationTest")]
    public ActionResult ValidationTest([FromBody] GenreDto genre)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Genre>> DeleteGenre(int id)
    {
        var genreToDelete = await _dbContext.Genres.FindAsync(id);

        if (genreToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Genres.Remove(genreToDelete);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

}