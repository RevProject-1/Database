using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClientManagement.DbService.Models
{
  [DataContract]
  public class UserDAO
  {
    [DataMember]
    public string Id { get; set; } 
    public string Name { get; set; }
    public string Email { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string SecurityStamp { get; set; }
    public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
    public int AccessFailedCount { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public bool LockoutEnabled { get; set; }
  }
}