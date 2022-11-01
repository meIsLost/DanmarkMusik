using DanmarkMusik.Managers;
using DanmarkMusik.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DanmarkMusik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusikRecordController : ControllerBase
    {
        private readonly MusikRecordManager _manager= new MusikRecordManager();        // GET: api/<RecordMusikController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<MusikRecord>> Get()
        {
           IEnumerable<MusikRecord> musikList =_manager.GetAll();
            if (musikList.Count() == 0)
            {
                return NoContent();
            }
            return Ok(musikList);
        }

        // GET api/<RecordMusikController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<MusikRecord> Get(int id)
        {
            MusikRecord? result = _manager.GetById(id);
            if (result == null)
                return NotFound();  
            else
                return Ok(result);
        }

        // POST api/<RecordMusikController>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<MusikRecord>Post([FromBody] MusikRecord value)
        {
            try
            {
                MusikRecord result = _manager.Add(value);
                return Created("api/footballplayers/" + result.Id, result);
            }
            catch (Exception ex)
            when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RecordMusikController>/5
        [HttpPut("{id}")]
        public ActionResult<MusikRecord> Put(int id, [FromBody] MusikRecord value)
        {
            try 
            {
                MusikRecord? result = _manager.Update(id, value);
                if (result == null)
                {
                    return NotFound();
                }
                else
                    return Ok(result);
            }
            catch (Exception ex)
                when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
           
         
        }

        // DELETE api/<RecordMusikController>/5
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public ActionResult<MusikRecord> Delete(int id)
        {
            MusikRecord? result = _manager.Delete(id);
            if (result != null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
