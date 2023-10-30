using Microsoft.EntityFrameworkCore;
using APINotas.Models;

namespace APINotas;

public class NotesContext: DbContext{
    public DbSet<Note> Notes {get; set;}

    public NotesContext(DbContextOptions<NotesContext> options) :base(options){ }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Note> notesInit = new List<Note>();
        notesInit.Add(new Note() { NoteId = Guid.NewGuid(), Title = "Lorem ipsum", Text="Lorem ipsum dolor sit AnimationMetadataType, consectetur adipiscing elit, sed to eiusmod tempor incididunt ut labore et dolore magna aligua"});
        notesInit.Add(new Note() { NoteId = Guid.NewGuid(), Title = "Shakespeare", Text="To be, or not to be: that is the question"});

        modelBuilder.Entity<Note>(note=>{
            note.ToTable("Note");
            note.HasKey(p=> p.NoteId);
            note.Property(p=> p.Title).IsRequired();
            note.Property(p=> p.Text).IsRequired(false).HasMaxLength(4000);

            note.HasData(notesInit);
        });
    }

}