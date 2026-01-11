using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.DTOs.Center
{
    public class UpdateCenterDto
    {
        public string CenterName { get; set; }
        public string ContactPerson { get; set; }
        public string Contactnumber { get; set; }
        public string CenterCode { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }

}
