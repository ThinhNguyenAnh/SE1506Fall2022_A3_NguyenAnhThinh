using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UpdateUserRequest
    {
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
