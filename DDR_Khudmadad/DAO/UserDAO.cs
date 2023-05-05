using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;
using System;

namespace DDR_Khudmadad.DAO
{
    public class UserDAO : IDAO
    {
        public UserDAO(Ef_DataContext context) : base(context)
        {
            
        }

        override public List<object>? GetAll()
        {
            List<object> response = new List<object>();
            var userList = _context.users.ToList();

            if (userList == null)
                return null;

            else
            {
                userList.ForEach(row => response.Add(new UsersModel()
                {
                    userId = row.userId,
                    roleId = row.roleId,
                    email = row.email,
                    userName = row.userName,
                    password = row.password,
                    firstName = row.firstName,
                    lastName = row.lastName,
                    dob = row.dob,
                    description = row.description,
                    phoneNumber = row.phoneNumber
                }));

                return response;
            }
        }

        override public UsersModel? GetById(int id)
        {
            UsersModel response = new UsersModel();
            var user = _context.users.Where(u => u.userId.Equals(id)).FirstOrDefault();
            if (user == null)
                return null;
            else
            {
                response.userId = user.userId;
                response.roleId = user.roleId;
                response.firstName = user.firstName;
                response.lastName = user.lastName;
                response.email = user.email;
                response.userName = user.userName;
                response.password = user.password;
                response.dob = user.dob;
                response.description = user.description;
                response.phoneNumber = user.phoneNumber;

                return response;
            }
        }

        override public void Add(object obj)
        {
            UsersModel user = (UsersModel)obj;
            Users u = new Users();
            u.userName = user.userName;
            u.email = user.email;
            u.roleId = user.roleId;
            u.firstName = user.firstName;
            u.lastName = user.lastName;
            u.password = user.password;
            u.dob = user.dob;
            u.description = user.description;
            u.phoneNumber = user.phoneNumber;

            _context.users.Add(u);
            _context.SaveChanges();
        }


        override public UsersModel? GetByUsername(string userName)
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

        override public bool Update(object obj)
        {
            UsersModel user = (UsersModel)obj;

            var _u = _context.users.Where(o => o.userId.Equals(user.userId)).FirstOrDefault();
            if (_u == null)
                return false;
            else
            {
                _u.firstName = user.firstName;
                _u.lastName = user.lastName;
                _u.password = user.password;
                _u.description = user.description;
                _u.phoneNumber = user.phoneNumber;
                _u.email = user.email;

                _context.SaveChanges();
                return true;
            }
        }

        override public bool Delete(object obj)
        {
            UsersModel user = (UsersModel)obj;

            var _u = _context.users.Where(u => u.userId.Equals(user.userId)).FirstOrDefault();
            if (_u == null)
                return false;
            else
            {
                _context.users.Remove(_u);
                _context.SaveChanges();
                return true;
            }

        }
    }
}
