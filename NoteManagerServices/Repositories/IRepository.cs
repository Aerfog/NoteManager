using NoteManagerServices.Entities;

namespace NoteManagerServices.Repositories;

/// <summary>
/// Represents a repository for storing a collection of objects of the <see cref="Note"/> type.
/// </summary>
public interface INoteRepository
{
    /// <summary>
    /// Gets a list of notes from the repository.
    /// </summary>
    /// <param name="skip">The number of notes to skip before adding an order to the result list.</param>
    /// <param name="count">The number of notes in the result list.</param>
    /// <returns>A <see cref="Task{TResult}"/>that wraps a list of notes.</returns>
    /// <remarks>The result list should be sorted by note id from smallest to largest.</remarks>
    Task<IList<Note>> GetNotesAsync(int skip, int count, string id);

    /// <summary>
    /// Gets an note with the specified identifier from the repository.
    /// </summary>
    /// <param name="noteId">The identifier of an note to return.</param>
    /// <returns>A <see cref="Task{TResult}"/> that wraps an note with the specified identifier.</returns>
    Task<Note> GetNoteAsync(Guid noteId, string id);

    /// <summary>
    /// Adds an note to the repository.
    /// </summary>
    /// <param name="note">An <see cref="Note"/>.</param>
    /// <returns>The identifier of an note to add.</returns>
    /// <returns>A <see cref="Task{T}"/> that wraps an identifier of an note that was added to the repository.</returns>
    Task<Guid> AddNoteAsync(Note note, string id);

    /// <summary>
    /// Removes an note with the specified identifier from the repository.
    /// </summary>
    /// <param name="noteId">The identifier of an note to remove.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    Task RemoveNoteAsync(Guid noteId, string id);

    /// <summary>
    /// Updates an note data with the specified identifier in the repository.
    /// </summary>
    /// <param name="note">The identifier of an note to update.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    Task UpdateNoteAsync(Note note, string id);
}