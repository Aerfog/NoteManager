using System.Runtime.Serialization;

namespace NoteManagerServices.Exceptions;

[Serializable]
public class NoteNotFoundException : Exception
{
    public NoteNotFoundException()
    {
    }

    public NoteNotFoundException(string message)
        : base(message)
    {
    }

    public NoteNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected NoteNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}