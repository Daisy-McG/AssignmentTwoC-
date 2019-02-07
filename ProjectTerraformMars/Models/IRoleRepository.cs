using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTerraformMars.Models
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        Role GetRoleById(int? id);
        void AddNewRole(Role role);
        void UpdateRole(Role role);
        void RemoveRole(Role role);
    }
}
