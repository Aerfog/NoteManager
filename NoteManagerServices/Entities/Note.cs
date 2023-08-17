namespace NoteManagerServices.Entities;

public class Note
{
    public Guid UserId { get; set; }
    public Guid NoteId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime? EditDateTime { get; set; }
}