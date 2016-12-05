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
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public string StreetAddress { get; set; }
    [DataMember]
    public string City { get; set; }
    [DataMember]
    public string State { get; set; }
    [DataMember]
    public string Zip { get; set; }
    [DataMember]
    public string PhoneNumber { get; set; }
    [DataMember]
    public string UserName { get; set; }
    [DataMember]
    public string PasswordHash { get; set; }
    [DataMember]
    public string SecurityStamp { get; set; }
    [DataMember]
    public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
    [DataMember]
    public int AccessFailedCount { get; set; }
    [DataMember]
    public bool EmailConfirmed { get; set; }
    [DataMember]
    public bool PhoneNumberConfirmed { get; set; }
    [DataMember]
    public bool TwoFactorEnabled { get; set; }
    [DataMember]
    public bool LockoutEnabled { get; set; }

  }
}