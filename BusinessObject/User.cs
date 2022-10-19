using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class User: IdentityUser<int>
    {

        public List<Order> Order { get; set; }
    }
}
