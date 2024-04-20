using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using System.Reflection.Metadata.Ecma335;
using data = Solution.DO.Objects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solution.API.Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private SolutionDbContext _context;
        public TasksController(SolutionDbContext context) 
        {
            this._context = context;
        }
        // GET: api/<TasksController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Tasks>>> GetAll()
        {
            return  new BS.Tasks(_context).GetAll().ToList();
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TasksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
