using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DbtaskContext _dbtaskContext;
        public TaskController(DbtaskContext dbtaskContext)
        {

            _dbtaskContext = dbtaskContext;

        }

        [HttpGet, Route("List")]
        public async Task<IActionResult> ListAll()
        {
            var listItems = await this._dbtaskContext.Tasks.ToListAsync();
            return Ok(listItems);
        }

        [HttpPost, Route("AddTask")]
        public async Task<IActionResult> AddTask([FromBody] Models.Task task)
        {

            _dbtaskContext.Tasks.Add(task);
            await _dbtaskContext.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete, Route("DeleteTask/{Id}")]
        public async Task<IActionResult> DeleteTask(int Id)
        {
            var itemToDelete = await _dbtaskContext.Tasks.FirstOrDefaultAsync(x => x.Id == Id);

            if (itemToDelete != null)
            {
                _dbtaskContext.Remove(itemToDelete);
                await _dbtaskContext.SaveChangesAsync();
            }
            else
            {
                return BadRequest("Task Not Found");
            }
            return Ok();
        }

    }
}
