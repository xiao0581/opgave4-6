using HusSagLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestHusSager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HusSagersController : ControllerBase
    {

        private readonly HusSagRepository _husSagRepository;
        public HusSagersController(HusSagRepository husSagRepository)
        {
            _husSagRepository = husSagRepository;
        }

        // GET: api/<HusSagersController>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<HusSag> Get()
        {
            List<HusSag> husSagsList = _husSagRepository.GetAll();
            if (husSagsList.Any())
            {
                
                return Ok(husSagsList);
            }
            else
            {
                return BadRequest("husSags not found");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<HusSag> Get(int id)
        {
            HusSag husSag = _husSagRepository.GetById(id);
            if (husSag == null)
            {
                return NotFound("No such husSag, id: \"" + id);
            }
            else
            {
                return Ok(husSag);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        
        [HttpPost]
        public ActionResult Post([FromBody] HusSag husSag)
        {
             _husSagRepository.Add(husSag);
            
            return Created("/" + husSag.Id, husSag);
        }

       
       
    }
}
