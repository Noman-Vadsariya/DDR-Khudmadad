using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;

namespace DDR_Khudmadad.DAO
{
    public class GigDAOImp : GenericDAOImp<Gig>
    {
        public GigDAOImp(Ef_DataContext context) : base(context)
        {

        }

        public List<object>? GetUnacceptedGigs()
        {
            List<object> response = new List<object>();
            var gigList = (from gig in _context.gig
                           join offer in _context.offer on gig.gigId equals offer.gigId into ps_jointable
                           from p in ps_jointable.DefaultIfEmpty()
                           where p.status != true
                           select new
                           {
                               creatorId = gig.creatorId,
                               gigId = gig.gigId,
                               gigName = gig.gigName,
                               description = gig.description,
                               deadline = gig.deadline,
                               pay = gig.pay
                           }).ToList();

            if (gigList == null)
                return null;
            else
            {
                gigList.ForEach(row => response.Add(new GigModel()
                {
                    creatorId = row.creatorId,
                    gigId = row.gigId,
                    gigName = row.gigName,
                    deadline = row.deadline,
                    description = row.description,
                    pay = row.pay
                }));

                return response;
            }
        }

        public List<object>? GetGigsByCreatorId(int creatorId)
        {
            List<object> response = new List<object>();
            var gigList = _context.gig.Where(o => o.creatorId.Equals(creatorId)).ToList();

            if (gigList == null)
                return null;

            else
            {
                gigList.ForEach(row => response.Add(new GigModel()
                {
                    creatorId = row.creatorId,
                    gigId = row.gigId,
                    gigName = row.gigName,
                    deadline = row.deadline,
                    description = row.description,
                    pay = row.pay
                }));

                return response;
            }
        }
    }
}
