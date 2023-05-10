using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;

namespace DDR_Khudmadad.DAO
{
    public class OfferDAOImp : GenericDAOImp<Offers>
    {
        public  OfferDAOImp(Ef_DataContext context) : base(context)
        {

        }

        public List<object>? GetOffersByGigId(int gigId)
        {
            List<object> response = new List<object>();
            var offerList = _context.offer.Where(o => o.gigId.Equals(gigId)).ToList();

            if (offerList == null)
                return null;
            else
            {
                foreach (var row in offerList)
                {
                    response.Add(new Offers()
                    {
                        gigId = row.gigId,
                        freelancerId = row.freelancerId,
                        pay = row.pay,
                        status = row.status
                    });
                }
                return response;
            }
        }

        public List<object>? GetOffersByFreelancerId(int freelancerId)
        {
            List<object> response = new List<object>();
            var offerList = _context.offer.Where(o => o.freelancerId.Equals(freelancerId)).ToList();
            if (offerList == null)
                return null;
            else
            {
                foreach (var row in offerList)
                {
                    response.Add(new Offers()
                    {
                        gigId = row.gigId,
                        freelancerId = row.freelancerId,
                        pay = row.pay,
                        status = row.status
                    });
                }
                return response;
            }
        }

        public List<object>? GetOffersByClientId(int clientId)
        {
            List<object> response = new List<object>();
            var offerList = (from offer in _context.offer
                             join gig in _context.gig on offer.gigId equals gig.gigId
                             join user in _context.users on offer.freelancerId equals user.userId
                             where gig.creatorId == clientId
                             select new
                             {
                                 clientId = gig.creatorId,
                                 gigId = gig.gigId,
                                 gigName = gig.gigName,
                                 freelancerId = offer.freelancerId,
                                 firstName = user.firstName,
                                 lastName = user.lastName,
                                 email = user.email,
                                 freelancerDescription = user.description,
                                 gigDescription = gig.description,
                                 deadline = gig.deadline,
                                 pay = offer.pay,
                                 status = offer.status
                             }).ToList();

            if (offerList == null)
                return null;
            else
            {
                foreach (var row in offerList)
                {
                    response.Add(new GigOfferModel()
                    {
                        clientId = row.clientId,
                        gigId = row.gigId,
                        gigName = row.gigName,
                        freelancerId = row.freelancerId,
                        firstName = row.firstName,
                        lastName = row.lastName,
                        email = row.email,
                        freelancerDescription = row.freelancerDescription,
                        gigDescription = row.gigDescription,
                        deadline = row.deadline,
                        pay = row.pay,
                        status = row.status
                    });
                }
                return response;
            }
        }

        public bool DeleteOffersWithGigId(int gigId)
        {
            var offerList = _context.offer.Where(o => o.gigId.Equals(gigId) && o.status == false).ToList();
            if (offerList == null)
                return false;
            else
            {
                foreach (var o in offerList)
                {
                    _context.offer.Remove(o);
                }
                _context.SaveChanges();
                return true;
            }
        }
    }
}
