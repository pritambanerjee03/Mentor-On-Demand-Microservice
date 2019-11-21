using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.AuthService.Models
{
    public class MODUser :IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [MaxLength(50)]
        public string Skills { get; set; }
       
        [MaxLength(50)]
        public string Experience { get; set; }

        public bool Active { get; set; }

    }
}
