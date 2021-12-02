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
    public class MatchesController : ControllerBase
    {
        private DataSource ds;
        public MatchesController()
        {
            ds = new DataSource(); //?
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> Get()
        {
            return await ds.Matches.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> Get(int id)
        {
            var Match = await ds.Matches.FirstOrDefaultAsync(x => x.Id == id);
            if (Match == null)
                return NotFound();
            return new ObjectResult(Match);
        }
    }
}
