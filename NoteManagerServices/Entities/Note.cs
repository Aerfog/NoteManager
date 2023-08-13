namespace NoteManagerServices.Entities;

public class Note
{
    public string UserLogin { get; set; }

    public User NoteUser { get; set; }
    public int NoteId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime? EditDateTime { get; set; }
}