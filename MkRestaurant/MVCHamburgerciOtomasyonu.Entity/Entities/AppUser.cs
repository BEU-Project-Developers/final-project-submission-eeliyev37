using Microsoft.AspNetCore.Identity;
using MVCHamburgerciOtomasyonu.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCHamburgerciOtomasyonu.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? ImageID { get; set; }
        public Image Image { get; set; }
    }
}
