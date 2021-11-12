using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace entityframework.Models
{
  public class AppUser:IdentityUser
  {
    [StringLength(400)]
    [Column(TypeName ="nvarchar")]
     public string HomeAddress{get;set;}
  }
}