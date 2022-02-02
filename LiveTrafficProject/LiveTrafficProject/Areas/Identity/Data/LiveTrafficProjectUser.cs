using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LiveTrafficProject.Models;
using Microsoft.AspNetCore.Identity;

namespace LiveTrafficProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the LiveTrafficProjectUser class
public class LiveTrafficProjectUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [ForeignKey("Language")]
    public string LanguageId { get; set; }
    public Language? Language { get; set; }
}

