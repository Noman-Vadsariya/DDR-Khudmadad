using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;

namespace DDR_Khudmadad.DAO
{
    public class GenericDAOImp<T> : GenericDAO<T> where T : class
    {
        public GenericDAOImp(Ef_DataContext context) : base(context)
        {

        }

        override public List<T>? GetAll()
        {
            List<object> response = new List<object>();
            var _List = _context.Set<T>().ToList();

            if (_List == null)
                return null;
            else
                return _List.ToList();
        }

        override public T? GetById(int id)
        {
            var user = _context.Set<T>().Find(id);
            if (user == null)
                return null;
            else
                return user;
        }

        override public void Add(object obj)
        {
            _context.Set<T>().Add((T)obj);
            _context.SaveChanges();
        }

        override public bool Update(object obj)
        {
            _context.Set<T>().Update((T)obj);
            _context.SaveChanges();
            return true;
        }

        override public bool Delete(object obj)
        {
            _context.Set<T>().Remove((T)obj);
            _context.SaveChanges();
            return true;
        }
    }
}
