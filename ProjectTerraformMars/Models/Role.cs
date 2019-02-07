using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTerraformMars.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }
        [Required]
        public string RoleDescription { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        public bool Permanent { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
