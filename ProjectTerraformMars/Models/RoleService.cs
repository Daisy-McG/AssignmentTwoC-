using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTerraformMars.Models
{
    public class RoleService : IRoleRepository
    {
        private readonly ProjectTerraformMarsContext _context;

        public RoleService(ProjectTerraformMarsContext context)
        {
            _context = context;
        }

        public void AddNewRole(Role role)
        {
            _context.Add(role);
            _context.SaveChanges();
        }

        public Role GetRoleById(int? id)
        {
            var role = _context.Role.FirstOrDefault(r => r.Id == id);
            return role;
        }

        public List<Role> GetRoles()
        {
            return _context.Role.ToList();
        }

        public void RemoveRole(Role role)
        {
            _context.Remove(role);
            _context.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            _context.Update(role);
            _context.SaveChanges();
        }
    }
}
