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

        abstract public List<object>? GetAll();
        abstract public object? GetById(int id);
        abstract public void Add(object obj);
        abstract public bool Update(object obj);
        abstract public bool Delete(object obj);
    }
}
