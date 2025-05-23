using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly AppDbContext _context;

    public LivrosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/livros
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livros>>> GetLivros()
    {
        var lista = await _context.Livros.ToListAsync();
        return Ok(lista);
    }

    // GET: api/livros/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Livros>> GetLivro(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null)
            return NotFound();
        return Ok(livro);
    }

    // POST: api/livros
    [HttpPost]
    public async Task<ActionResult<Livros>> PostLivro(Livros livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livro);
    }

    // PUT: api/livros/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLivro(int id, Livros livro)
    {
        if (id != livro.Id)
            return BadRequest();

        _context.Entry(livro).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/livros/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLivro(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null)
            return NotFound();

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
