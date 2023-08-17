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
    
    [Route("[controller]/[action]/{noteId}")]
    [HttpGet("{noteId}")] // GET}
    public IActionResult Get(Guid noteId)
    {
        var notes = _context.Notes?.Where(n => n.NoteId.Equals(noteId)).ToList();
        return View(notes);
    }
}