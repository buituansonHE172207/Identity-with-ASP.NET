using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace withEF.Models
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "NVARCHAR")]
        [StringLength(400)]
        public string? HomeAddress { get; set; }       
    }
}