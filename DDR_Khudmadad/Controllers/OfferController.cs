using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;
using DDR_Khudmadad.DAO;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDR_Khudmadad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly OfferDAOImp _db;

        public OfferController(Ef_DataContext _context)
        {
            _db = new OfferDAOImp(_context);
        }

        public Offers TransformObject(OfferModel offer)
        {
            Offers o = new Offers();
            o.freelancerId = offer.freelancerId;
            o.gigId = offer.gigId;
            o.pay = offer.pay;
            o.status = offer.status;
            return o;
        }

        // GET: api/Offer
        [HttpGet]
        public ApiResponse Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<object>? data = _db.GetAll();

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return ResponseHandler.GetAppResponse(type, data);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }

        }

        //GET: api/Offer/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
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
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        //GET: api/Offer/gigId/5
        [HttpGet("gigId/{gigId}")]
        public ApiResponse GetOffersByOfferId(int gigId)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<object>? data = _db.GetOffersByGigId(gigId);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return ResponseHandler.GetAppResponse(type, data);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        //GET: api/Offer/freelancerId/5
        [HttpGet("freelancerId/{freelancerId}")]
        public ApiResponse GetOffersByFreelancerId(int freelancerId)
        {
            ResponseType type = ResponseType.Success;
            Console.WriteLine("\n\n" + freelancerId + "\nHello");
            try
            {
                IEnumerable<object>? data = _db.GetOffersByFreelancerId(freelancerId);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return ResponseHandler.GetAppResponse(type, data);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        //GET: api/Offer/clientId/5
        [HttpGet("clientId/{clientId}")]
        public ApiResponse GetOffersByClientId(int clientId)
        {
            ResponseType type = ResponseType.Success;
            Console.WriteLine("\n\n" + clientId + "\nHello");
            try
            {
                IEnumerable<object>? data = _db.GetOffersByClientId(clientId);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return ResponseHandler.GetAppResponse(type, data);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        // GET: api/Offer/Create
        [HttpPost("Create")]
        public ApiResponse Create(OfferModel o)
        {
            try
            {
                var offer = this.TransformObject(o);
                _db.Add(offer);
                return ResponseHandler.GetAppResponse(ResponseType.Success, offer);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        [HttpPut("UpdateStatus")]
        public ApiResponse UpdateOfferStatus(OfferModel o)
        {
            try
            {
                var offer = this.TransformObject(o);
                var _o = _db.Update(offer);
                if(_o)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _o);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _o);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }
        //Delete
        [HttpDelete("delete")]
        public ApiResponse DeleteOffer(OfferModel o)
        {
            try
            {
                var offer = this.TransformObject(o);
                var _o = _db.Delete(offer);
                if(_o)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _o);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _o);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        //Delete all offers with given gigId accept the one accepted by client
        [HttpDelete("delete/{gigId}")]
        public ApiResponse DeleteOfferGivenGigId(int gigId)
        {
            try
            {
                var _o = _db.DeleteOffersWithGigId(gigId);
                if (_o)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _o);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _o);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }
    }
}
