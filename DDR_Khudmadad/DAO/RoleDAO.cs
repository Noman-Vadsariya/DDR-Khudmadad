using DDR_Khudmadad.BusinessObjects;
using DDR_Khudmadad.DTO;
using Npgsql.Replication;
using System;

namespace DDR_Khudmadad.DAO
{
    public class RoleDAO : IDAO
    {
        public RoleDAO(Ef_DataContext context) : base(context)
        {

        }

        override public List<object>? GetAll()
        {
            List<object> response = new List<object>();
            var roleList = _context.roles.ToList();

            if (roleList == null)
                return null;

            else
            {
                roleList.ForEach(row => response.Add(new RolesModel()
                {
                    roleId = row.roleId,
                    role = row.role
                }));

                return response;
            }
        }

        override public RolesModel? GetById(int id)
        {
            RolesModel response = new RolesModel();

            var r = _context.roles.Where(r => r.roleId.Equals(id)).FirstOrDefault();
            
            if (r == null)
                return null;
            else
            {
                response.roleId = r.roleId;
                response.role = r.role;

                return response;
            }
        }

        override public void Add(object obj)
        {
            RolesModel role = (RolesModel)obj;

            Roles r = new Roles();
            r.roleId = role.roleId;
            r.role = role.role;

            _context.roles.Add(r);
            _context.SaveChanges();
        }

        override public bool Update(object obj)
        {
            RolesModel role = (RolesModel)obj;

            var _r = _context.roles.Where(o => o.roleId.Equals(role.roleId)).FirstOrDefault();
            
            if (_r == null)
                return false;
            else
            {
                _r.roleId = _r.roleId;
                _r.role = _r.role;

                _context.SaveChanges();
                return true;
            }
        }

        override public bool Delete(object obj)
        {
            RolesModel role = (RolesModel)obj;

            var _r = _context.roles.Where(r => r.roleId.Equals(role.roleId)).FirstOrDefault();
            
            if (_r == null)
                return false;
            else
            {
                _context.roles.Remove(_r);
                _context.SaveChanges();
                return true;
            }

        }
    }
}
