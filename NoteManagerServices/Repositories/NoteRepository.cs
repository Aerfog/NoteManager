﻿using NoteManagerServices.AppDbContext;
using NoteManagerServices.Entities;
using NoteManagerServices.Exceptions;

namespace NoteManagerServices.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly ApplicationDbContext _context;

    public NoteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<Note>> GetNotesAsync(int skip, int count, string id)
    {
        return await Task.Run(async () =>
        {
            try
            {
                var noteList = new List<Note>();
                var idList = _context.Notes?.Where(n => n.UserId.ToString().Equals(id))
                    .Skip(skip)
                    .Take(count)
                    .Select(n => n.NoteId)
                    .OrderBy(n => n)
                    .ToList();
                if (idList == null)
                    throw new NoteNotFoundException();

                foreach (var guid in idList)
                {
                    noteList.Add(await GetNoteAsync(guid, id));
                }

                return noteList;
            }
            catch (NoteNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
    }

    public async Task<Note> GetNoteAsync(Guid noteId, string id)
    {
        return await Task.Run(() =>
        {
            try
            {
                var note = _context.Notes?.Where(n => n.NoteId.Equals(noteId)).FirstOrDefault();
                if (note == null)
                {
                    throw new NoteNotFoundException();
                }
                if (!note.UserId.ToString().Equals(id))
                {
                    throw new Exception();
                }
                

                return note;
            }
            catch (NoteNotFoundException notFoundException)
            {
                Console.WriteLine(notFoundException);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
    }

    public async Task<Guid> AddNoteAsync(Note note, string id)
    {
        return await Task.Run(() =>
        {
            try
            {
                note.CreateDateTime = DateTime.Now;
                note.UserId = new Guid(id);
                _context.Notes?.Add(note);
                _context.SaveChanges();
                return note.NoteId;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        });
    }

    public async Task RemoveNoteAsync(Guid noteId, string id)
    {
        await Task.Run(async () =>
        {
            try
            {
                var note = await GetNoteAsync(noteId, id);
                _context.Notes?.Remove(note);
                await _context.SaveChangesAsync();
            }
            catch (NoteNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
    }

    public async Task UpdateNoteAsync(Note note, string id)
    {
        await Task.Run(async () =>
        {
            try
            {
                var oldNote = await GetNoteAsync(note.NoteId, id);
                oldNote.EditDateTime = DateTime.Now;
                oldNote.Title = note.Title;
                oldNote.Body = note.Body;
                await _context.SaveChangesAsync();
            }
            catch (NoteNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
    }
}