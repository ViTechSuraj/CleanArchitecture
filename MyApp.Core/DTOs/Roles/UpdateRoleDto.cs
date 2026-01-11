using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.DTOs.Roles
{
    public class UpdateRoleDto
    {
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    }
}
