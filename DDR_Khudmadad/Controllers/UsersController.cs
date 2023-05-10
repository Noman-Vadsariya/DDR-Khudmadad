using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;
using DDR_Khudmadad.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DDR_Khudmadad.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDAOImp _db;

        public UsersController(Ef_DataContext _context)
        {
            _db = new UserDAOImp(_context);
        }

        public Users TransformObject(UsersModel user)
        {
            Users u = new Users();
            u.userId = user.userId;
            u.roleId = user.roleId;
            u.userName = user.userName;
            u.email = user.email;
            u.password = user.password;
            u.firstName = user.firstName;
            u.lastName = user.lastName;
            u.dob = user.dob;
            u.description = user.description;
            u.phoneNumber = user.phoneNumber;
            return u;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<object>? data = _db.GetAll();

                if(data==null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        //GET: api/Users/userid/{id}
        [HttpGet("userid/{id}")]
        public ActionResult GetUserById(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                object? data = _db.GetById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        //GET: api/Users/username/{userName}
        [HttpGet("username/{userName}")]
        public ActionResult GetUserByUsername(string userName)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                object? data = _db.GetByUsername(userName);
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

        // GET: api/Users/create
        [HttpPost("create")]
        public ActionResult Create(UsersModel user)
        {
            try
            {
                var u = this.TransformObject(user);
                _db.Add(u);
                return Ok(ResponseHandler.GetAppResponse(ResponseType.Success, user));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut("update")]
        public ApiResponse UpdateUser(UsersModel user)
        {
            try
            {
                var u = this.TransformObject(user);
                var _u = _db.Update(u);
                if (_u)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _u);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _u);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        [HttpDelete("delete")]
        public ApiResponse DeleteOffer(UsersModel user)
        {
            try
            {
                var u = this.TransformObject(user);
                var _u = _db.Delete(u);

                if (_u)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _u);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _u);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

    }
}
