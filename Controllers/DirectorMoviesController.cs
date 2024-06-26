﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorMoviesController : ControllerBase
    {
        private readonly CinemaAPIContext _context;

        public DirectorMoviesController(CinemaAPIContext context)
        {
            _context = context;
        }

        // GET: api/DirectorMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorMovie>>> GetDirectorMovies()
        {
            return await _context.DirectorMovies.ToListAsync();
        }

        // GET: api/DirectorMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorMovie>> GetDirectorMovie(int id)
        {
            var directorMovie = await _context.DirectorMovies.FindAsync(id);

            if (directorMovie == null)
            {
                return NotFound();
            }

            return directorMovie;
        }

        // PUT: api/DirectorMovies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectorMovie(int id, DirectorMovie directorMovie)
        {
            if (id != directorMovie.Id)
            {
                return BadRequest();
            }

            _context.Entry(directorMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorMovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DirectorMovies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DirectorMovie>> PostDirectorMovie(DirectorMovie directorMovie)
        {
            _context.DirectorMovies.Add(directorMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectorMovie", new { id = directorMovie.Id }, directorMovie);
        }

        // DELETE: api/DirectorMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirectorMovie(int id)
        {
            var directorMovie = await _context.DirectorMovies.FindAsync(id);
            if (directorMovie == null)
            {
                return NotFound();
            }

            _context.DirectorMovies.Remove(directorMovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectorMovieExists(int id)
        {
            return _context.DirectorMovies.Any(e => e.Id == id);
        }
    }
}
