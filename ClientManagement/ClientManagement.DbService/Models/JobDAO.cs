using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClientManagement.DbService.Models
{
  [DataContract]
  public class JobDAO
  {
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public int ServiceTypeID { get; set; }
    [DataMember]
    public int ClientID { get; set; }
    [DataMember]
    public string UserID { get; set; }
    [DataMember]
    public Nullable<System.DateTime> StartDate { get; set; }
    [DataMember]
    public Nullable<int> EstimatedDuration { get; set; }
    [DataMember]
    public string Notes { get; set; }
    [DataMember]
    public int? ExpenseID { get; set; }
    [DataMember]
    public bool Complete { get; set; }

    [DataMember]
    public virtual UserDAO User { get; set; }
    [DataMember]
    public virtual ClientDAO Client { get; set; }
    [DataMember]
    public virtual ExpenseDAO Expense { get; set; }
    [DataMember]
    public virtual ServiceTypeDAO ServiceType { get; set; }


  }
}