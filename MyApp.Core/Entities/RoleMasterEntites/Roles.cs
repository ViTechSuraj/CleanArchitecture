using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Entities.RoleMasterEntites
{
    public class Roles : BaseEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }

}
