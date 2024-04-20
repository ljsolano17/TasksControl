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
            try
            {
                return new BS.Tasks(_context).GetAll().ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Tasks>> GetById(int id)
        {
            try
            {
                return new BS.Tasks(_context).GetById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<ActionResult<data.Tasks>> Post([FromBody] data.Tasks tasks)
        {
            try
            {
                if (tasks == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    new BS.Tasks(_context).Insert(tasks);
                    return CreatedAtAction("GetAll", new { taskId = tasks.TaskId }, tasks);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<data.Tasks>> Put(int id, [FromBody] data.Tasks tasks)
        {
            try
            {
                if (id != null && tasks != null)
                {
                    new BS.Tasks(_context).Update(tasks);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Tasks>> Delete(int id)
        {
            try
            {
                var task = new BS.Tasks(_context).GetById(id);
                if (task != null)
                {
                    new BS.Tasks(_context).Delete(task);
                    return StatusCode(200, task);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return (new BS.Tasks(_context).GetById(id) != null);
        }
    }
}
