public class EmpleoService
{
    private readonly Contexto _context;

    public EmpleoService(Contexto context)
    {
        _context = context;
    }

    public async Task<bool> Guardar(Empleo empleo)
    {
        if (!EmpleoExists(empleo.EmpleoId))
            _context.Empleo.Add(empleo);
        else
            _context.Empleo.Update(empleo);

        var cantidad = await _context.SaveChangesAsync();
        return cantidad > 0;
    }

    private bool EmpleoExists(int id)
    {
        return (_context.Empleo?.Any(e => e.EmpleoId == id)).GetValueOrDefault();
    }
}