using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
       
        override public string UserId { get; set; }
        [ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; }

        override public string RoleId { get; set; }
    }
}
