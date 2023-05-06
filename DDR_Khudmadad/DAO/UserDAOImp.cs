using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;

namespace DDR_Khudmadad.DAO
{
    public class UserDAOImp : GenericDAOImp<Users>
    {
        public UserDAOImp(Ef_DataContext context) : base(context)
        {
            
        }

        public UsersModel? GetByUsername(string userName)
        {
            UsersModel response = new UsersModel();
            var user = _context.users.Where(u => u.userName.Equals(userName)).FirstOrDefault();
            if (user == null)
                return null;
            else
            {
                response.userId = user.userId;
                response.roleId = user.roleId;
                response.firstName = user.firstName;
                response.lastName = user.lastName;
                response.userName = user.userName;
                response.password = user.password;
                response.email = user.email;
                response.dob = user.dob;
                response.description = user.description;
                response.phoneNumber = user.phoneNumber;

                return response;
            }
        }
    }
}
