using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMarket.Core.Entities.SecurityEntities
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
