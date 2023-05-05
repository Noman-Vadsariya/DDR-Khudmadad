using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;
using Npgsql.Replication;
using System;

namespace DDR_Khudmadad.DAO
{
    public class GigDAO : IDAO
    {
     
        public GigDAO(Ef_DataContext context) : base(context)
        {
            
        }

        override public List<object>? GetAll()
        {
            var response = new List<object>();
            var gigList = _context.gig.ToList();

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
       
        override public GigModel? GetById(int id)
        {
            GigModel g = new GigModel();
            var gig = _context.gig.Where(u => u.gigId.Equals(id)).FirstOrDefault();
            if (gig == null)
                return null;
            else
            {
                g.creatorId = gig.creatorId;
                g.gigId = gig.gigId;
                g.gigName = gig.gigName;
                g.deadline = gig.deadline;
                g.description = gig.description;
                g.pay = gig.pay;

                return g;
            }
        }

        override public List<object>? GetUnacceptedGigs()
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

        override public List<object>? GetGigsByCreatorId(int creatorId)
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

        override public void Add(object obj)
        {
            GigModel gig = (GigModel)obj;

            Gig g = new Gig();
            g.creatorId = gig.creatorId;
            g.deadline = gig.deadline;
            g.gigName = gig.gigName;
            g.description = gig.description;
            g.pay = gig.pay;

            _context.gig.Add(g);
            _context.SaveChanges();
        }


        override public bool Update(object obj)
        {
            GigModel gig = (GigModel)obj;

            var _g = _context.gig.Where(g => g.gigId.Equals(gig.gigId)).FirstOrDefault();

            if (_g == null)
                return false;
            else
            {
                _g.pay = gig.pay;
                _g.description = gig.description;
                _g.gigName = gig.gigName;
                _g.deadline = gig.deadline;
                _context.SaveChanges();
                return true;
            }
        }

        override public bool Delete(object obj)
        {
            GigModel gig = (GigModel)obj;

            var _g = _context.gig.Where(g => g.gigId.Equals(gig.gigId)).FirstOrDefault();
            if (_g == null)
                return false;
            else
            {
                _context.gig.Remove(_g);
                _context.SaveChanges();
                return true;
            }
        }

    }
}
