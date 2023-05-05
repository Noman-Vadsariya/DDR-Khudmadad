using DDR_Khudmadad.BusinessObjects;
using Microsoft.Identity.Client;

namespace DDR_Khudmadad.DAO
{
    public abstract class IDAO
    {
        public Ef_DataContext _context { get; set; }

        public IDAO(Ef_DataContext context)
        {
            _context = context;
        }

        //primary functions - these functions must be implemented by each class
        abstract public List<object>? GetAll();
        abstract public object? GetById(int id);
        abstract public void Add(object obj);
        abstract public bool Update(object obj);
        abstract public bool Delete(object obj);

        //secondary functions - not neccessary to implement
        virtual public object? GetByUsername(string username)
        {
            Console.WriteLine("Not Applicable");
            return null;
        }

        virtual public List<object>? GetUnacceptedGigs()
        {
            Console.WriteLine("Not Applicable");
            return null;
        }

        virtual public List<object>? GetGigsByCreatorId(int id)
        {
            Console.WriteLine("Not Applicable");
            return null;
        }

        virtual public List<object>? GetOfferByFreelancerId(int id)
        {
            Console.WriteLine("Not Applicable");
            return null;
        }

        virtual public List<object>? GetOffersByClientId(int id)
        {
            Console.WriteLine("Not Applicable");
            return null;
        }

        virtual public List<object>? GetOfferByGigId(int gigId)
        {
            Console.WriteLine("Not Applicable");
            return null;
        }

        virtual public bool DeleteOffersWithGigId(int gigId)
        {
            Console.WriteLine("Not Applicable");
            return false;
        }
    }
}
