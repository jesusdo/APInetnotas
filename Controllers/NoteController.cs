using APINotas.Models;
using APINotas.Services;
using Microsoft.AspNetCore.Mvc;

namespace APINotas.Controllers;

[Route("api/[controller]")]
public class NoteController : ControllerBase{
    INoteService noteService;

    public NoteController(INoteService service){
        noteService = service;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(noteService.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Note note){
        await noteService.Save(note);
        return Ok("Insert was success");
    }

    [HttpPut]
    public async Task<IActionResult> Put(Guid id, [FromBody] Note note){
        await noteService.Update(id, note);
        return Ok("Update was success");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id){
        await noteService.Delete(id);
        return Ok("Delete was success");
    }
}