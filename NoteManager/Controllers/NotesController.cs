using Microsoft.AspNetCore.Mvc;
using NoteManagerServices.AppDbContext;

namespace NoteManager.Controllers;

public class NotesController : Controller
{
    private readonly ILogger<NotesController> _logger;
    private readonly ApplicationDbContext _context;

    public NotesController(ILogger<NotesController> logger,[FromServices] ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [Route("[controller]/[action]/{userLogin}")]
    [HttpGet("{userLogin}")] // GET}
    public IActionResult Get(string userLogin)
    {
        var notes = _context.Notes?.Where(n => n.UserLogin.Equals(userLogin)).First();
        return View(notes);
    }
}