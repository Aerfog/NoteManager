namespace NoteManagerServices.Entities;

public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public ICollection<Note> Notes { get; set; }
}