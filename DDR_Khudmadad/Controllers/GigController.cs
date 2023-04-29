using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;
using DDR_Khudmadad.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDR_Khudmadad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GigController : ControllerBase
    {
        private readonly GigDAO _db;

        public GigController(Ef_DataContext _context)
        {
            _db = new GigDAO(_context);
        }

        // GET: api/Gigs
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<object>? data = _db.GetAll();

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        } 
        
        // GET: api/Gig/creatorId/{creatorId}
        [HttpGet("creatorId/{creatorId}")]
        public IActionResult GetGigByCreatorId(int creatorId)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<GigModel>? data = _db.GetGigsByCreatorId(creatorId);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }
        
        // GET: api/Gig/unaccepted
        [HttpGet("unaccepted")]
        public IActionResult GetUnacceptedGigs()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<GigModel>? data = _db.GetUnacceptedGigs();

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        //GET: api/Gigs/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                GigModel? data = _db.GetById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        // GET: api/Gigs/Create
        [HttpPost("Create")]
        public ActionResult Create(GigModel gig)
        {
            try
            {
                _db.Add(gig);
                return Ok(ResponseHandler.GetAppResponse(ResponseType.Success, gig));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut("update")]
        public ApiResponse UpdateGig(GigModel gig)
        {
            try
            {
                var _g = _db.Update(gig);
                if (_g)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _g);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _g);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        [HttpDelete("delete")]
        public ApiResponse DeleteGig(GigModel gig)
        {
            try
            {
                var _g = _db.Delete(gig);
                if (_g)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _g);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _g);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }
    }
}
