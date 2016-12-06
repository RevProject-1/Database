using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClientManagement.DbService.Models
{
  [DataContract]
  public class ClientDAO
  {
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public Nullable<int> AddressID { get; set; }
    [DataMember]
    public string PhoneNumber { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public string UserId { get; set; }
    [DataMember]
    public virtual AddressDAO Address { get; set; }
  }
}