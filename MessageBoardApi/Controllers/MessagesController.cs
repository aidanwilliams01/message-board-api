using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;

namespace MessageBoardApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public MessagesController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [HttpGet("{group}")]
    public async Task<ActionResult<IEnumerable<Message>>> Get(string group, string earlierDateTime, string laterDateTime)
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();
      query = query.Where(entry => entry.Group == group);

      if (earlierDateTime != null)
      {
        query = query.Where(entry => entry.MessageDateTime >= DateTime.Parse(earlierDateTime));
      }

      if (laterDateTime != null)
      {
        query = query.Where(entry => entry.MessageDateTime <= DateTime.Parse(laterDateTime));
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      Message message = await _db.Messages.FindAsync(id);

      if (message == null)
      {
        return NotFound();
      }

      return message;
    }

    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, message);
    }

    // [Route("api/Groups")]
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<string>>> Get()
    // {
    //   IQueryable<Message> query = _db.Messages.AsQueryable();
    //   IQueryable<string> groups = query.GroupBy(x => x.Group).Select(g => g.First()).Select(h => h.Group);

    //   return await groups.ToListAsync();
    // }

    [HttpPut("{id}/{userName}")]
    public async Task<IActionResult> Put(int id, string userName, Message message)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }

      Message messageToModify = await _db.Messages.FindAsync(id);
      if (userName != messageToModify.UserName)
      {
        return BadRequest();
      }
      
      _db.ChangeTracker.Clear();
      _db.Messages.Update(message);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }

    [HttpDelete("{id}/{userName}")]
    public async Task<IActionResult> DeleteMessage(int id, string userName)
    {
      Message message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }

      if (userName != message.UserName)
      {
        return BadRequest();
      }

      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}