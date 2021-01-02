using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSonHal.Models
{
    public class AppRole : IdentityRole
    {
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
