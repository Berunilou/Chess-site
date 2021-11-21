using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        DataSource db;
        public PlayersController(DataSource context)
        {
            db = context;
            if (!db.Players.Any())
            {
                db.Players.Add(new Player { Name = "Tom", Reit = 26 });
                db.Players.Add(new Player { Name = "Alice", Reit = 31 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            return await db.Players.ToListAsync();
        }

        // GET api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            Player Player = await db.Players.FirstOrDefaultAsync(x => x.Id == id);
            if (Player == null)
                return NotFound();
            return new ObjectResult(Player);
        }

        // POST api/Players
        [HttpPost]
        public async Task<ActionResult<Player>> Post(Player Player)
        {
            if (Player == null)
            {
                return BadRequest();
            }

            db.Players.Add(Player);
            await db.SaveChangesAsync();
            return Ok(Player);
        }

        // PUT api/Players/
        [HttpPut]
        public async Task<ActionResult<Player>> Put(Player Player)
        {
            if (Player == null)
            {
                return BadRequest();
            }
            if (!db.Players.Any(x => x.Id == Player.Id))
            {
                return NotFound();
            }

            db.Update(Player);
            await db.SaveChangesAsync();
            return Ok(Player);
        }

        // DELETE api/Players/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> Delete(int id)
        {
            Player Player = db.Players.FirstOrDefault(x => x.Id == id);
            if (Player == null)
            {
                return NotFound();
            }
            db.Players.Remove(Player);
            await db.SaveChangesAsync();
            return Ok(Player);
        }
    }
}
