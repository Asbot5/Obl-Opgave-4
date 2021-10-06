using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OblFootballPlayer;

namespace FootballPlayerREST.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        private readonly FootballPlayerManager _manager = new FootballPlayerManager();

        [HttpGet]
        public IEnumerable<FootballPlayer> Get()
        {
            return _manager.GetAll();
        }
        
        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer player = _manager.GetById(id);
            if (player == null) return NotFound("No such item, id: " + id);
            return player;
        }
        
        [HttpPost]
        public FootballPlayer Post([FromBody] FootballPlayer value)
        {
            return _manager.Add(value);
        }
        
        [HttpPut("{id}")]
        public FootballPlayer Put(int id, [FromBody] FootballPlayer value)
        {
            return _manager.Update(id, value);
        }
        
        [HttpDelete("{id}")]
        public FootballPlayer Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
