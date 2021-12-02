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
    public class MovesController : ControllerBase
    {
        private DataSource ds;
        public MovesController()
        {
            ds = new DataSource(); //?
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Move>>> Get()
        {
            return await ds.Moves.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Move>> Get(int id)
        {
            var Move = await ds.Moves.FirstOrDefaultAsync(x => x.Id == id);
            if (Move == null)
                return NotFound();
            return new ObjectResult(Move);
        }
    }
}
