using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FinalProjectUser class
public class FinalProjectUser : IdentityUser
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Phone { get; set; }

}

