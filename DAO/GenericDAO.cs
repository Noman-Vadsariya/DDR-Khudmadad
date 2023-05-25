using DDR_Khudmadad.BusinessObjects;
using Microsoft.Identity.Client;

namespace DDR_Khudmadad.DAO
{
    public abstract class GenericDAO<T> where T : class
    {
        public Ef_DataContext _context { get; set; }
        
        public GenericDAO(Ef_DataContext context)
        {
            _context = context;
        }

        //primary functions - these functions must be implemented by each class
        abstract public List<T>? GetAll();
        abstract public T? GetById(int id);
        abstract public void Add(object obj);
        abstract public bool Update(object obj);
        abstract public bool Delete(object obj);
    }
}
