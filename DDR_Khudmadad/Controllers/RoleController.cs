using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;
using DDR_Khudmadad.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace DDR_Khudmadad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly GenericDAOImp<Roles> _db;

        public RoleController(Ef_DataContext _context)
        {
            _db = new GenericDAOImp<Roles>(_context);
        }

        public Roles TransformObject(RolesModel role)
        {
            Roles r = new Roles();
            r.roleId = role.roleId;
            r.role = role.role;
            return r;
        }

        // GET: api/roles
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

        // GET: api/roles/Create
        [HttpPost("Create")]
        public ActionResult Create(RolesModel r)
        {
            try
            {
                var role = this.TransformObject(r);
                _db.Add(role);
                return Ok(ResponseHandler.GetAppResponse(ResponseType.Success, role));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
