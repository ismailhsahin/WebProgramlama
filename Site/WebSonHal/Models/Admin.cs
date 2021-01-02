using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSonHal.Models
{
    public class Admin : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
