using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;

namespace DDR_Khudmadad.DAO
{
    public class UserDAOImp : GenericDAOImp<Users>
    {
        public UserDAOImp(Ef_DataContext context) : base(context)
        {
            
        }

        public object? GetByUsername(string userName)
        {
            var user = _context.users.Where(u => u.userName.Equals(userName)).FirstOrDefault();
            if (user == null)
                return null;
            else
                return user;
        }
    }
}
