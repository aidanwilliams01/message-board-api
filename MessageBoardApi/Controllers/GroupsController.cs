using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;

namespace MessageBoardApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GroupsController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public GroupsController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Group>>> Get()
    {
      IQueryable<Group> query = _db.Groups.AsQueryable();

      return await query.ToListAsync();
    }
  }
}