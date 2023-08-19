using Microsoft.AspNetCore.Mvc;
using NoteManagerServices.AppDbContext;
using NoteManagerServices.Entities;
using NoteManagerServices.Repositories;

namespace NoteManager.Controllers;

public class NotesController : Controller
{
    private readonly ILogger<NotesController> _logger;
    private readonly INoteRepository _repository;

    public NotesController(ILogger<NotesController> logger,[FromServices] INoteRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    [Route("[controller]/[action]/{noteId}")]
    [HttpGet("{noteId}")] // GET}
    public async Task<IActionResult> Get(Guid noteId)
    {
        return await Task.Run(async () =>
        {
            var user = HttpContext.User.Claims.ToList();
            if (user.Count == 0)
            {
                return Redirect("~/Identity/Account/Login") as IActionResult;
            }
            var userId = user.ToList()[0].Value;
            var note = await _repository.GetNoteAsync(noteId, userId);
            var noteList = new List<Note>(){note};
            return View(noteList);
        });
    }
    [Route("[controller]/[action]/")]
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        return await Task.Run(async () =>
        {
            var user = HttpContext.User.Claims.ToList();
            if (user.Count == 0)
            {
                return Redirect("~/Identity/Account/Login") as IActionResult;
            }
            var userId = user.ToList()[0].Value;
            var notes = await _repository.GetNotesAsync(0, 4, userId);
            return View(notes);
        });
    }
}