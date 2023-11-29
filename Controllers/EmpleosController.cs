using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class EmpleosController : ControllerBase
{
    private readonly Contexto _context;

    public EmpleosController(Contexto context)
    {
        _context = context;
    }

    // GET: api/Empleos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleo>>> GetEmpleos()
    {
        if (_context.Empleo == null)
        {
            return NotFound();
        }
        return await _context.Empleo.ToListAsync();
    }

    // GET: api/Empleos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Empleo>> GetEmpleo(int id)
    {
        if (_context.Empleo == null)
        {
            return NotFound();
        }
        var empleo = await _context.Empleo
            .Where(e => e.EmpleoId == id)
            .FirstOrDefaultAsync();

        if (empleo == null)
        {
            return NotFound();
        }

        return empleo;
    }

    // POST: api/Empleos
    [HttpPost]
    public async Task<ActionResult<Empleo>> PostEmpleo(Empleo empleo)
    {
        if (!EmpleoExists(empleo.EmpleoId))
            _context.Empleo.Add(empleo);
        else
            _context.Empleo.Update(empleo);

        await _context.SaveChangesAsync();

        return Ok(empleo);
    }

    // DELETE: api/Empleos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmpleo(int id)
    {
        if (_context.Empleo == null)
        {
            return NotFound();
        }
        var empleo = await _context.Empleo.FindAsync(id);
        if (empleo == null)
        {
            return NotFound();
        }

        _context.Empleo.Remove(empleo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EmpleoExists(int id)
    {
        return (_context.Empleo?.Any(e => e.EmpleoId == id)).GetValueOrDefault();
    }
}
