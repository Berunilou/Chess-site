using DataLayer;
using DataLayer.Entities;
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
    public class GameController : ControllerBase
    {
        private DataSource ds;
        public GameController()
        {
            ds = new DataSource(); //?
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Get()
        {
            return await ds.Games.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            Game game = await ds.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
                return NotFound();
            return new ObjectResult(game);
        }
    }
}
