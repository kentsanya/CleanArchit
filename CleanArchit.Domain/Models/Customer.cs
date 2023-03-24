using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CleanArchit.Domain.Models
{
    public class Customer
    {
        public int Rank { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
