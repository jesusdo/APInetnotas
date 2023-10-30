using APINotas.Models;

namespace APINotas.Services;

public class NoteService: INoteService{
    NotesContext context;

    public NoteService(NotesContext dbContext){
        context = dbContext;
    }

    public IEnumerable<Note> Get(){
        return context.Notes;
    }

    public async Task<Note> Save(Note note){
        await context.AddAsync(note);
        await context.SaveChangesAsync();
        return note;
    }

    public async Task Update(Guid id, Note note){
        var noteActual = context.Notes.Find(id);

        if(noteActual != null){
            noteActual.Title = note.Title;
            noteActual.Text = note.Text;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id){
        var noteActual = context.Notes.Find(id);

        if(noteActual != null){
            context.Remove(noteActual);

            await context.SaveChangesAsync();
        }
    }
}

public interface INoteService{
    public IEnumerable<Note> Get();

    Task<Note> Save(Note note);

    Task Update(Guid id, Note note);

    Task Delete(Guid id);
}