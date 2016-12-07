using ClientManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClientManagement.DbService.Models
{
  [DataContract]
  public class ExpenseDAO
  {
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public decimal Cost { get; set; }
   
  }
}