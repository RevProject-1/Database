using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClientManagement.DbService.Models
{
  [DataContract]
  public class JobExpenseDAO
  {
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public int JobID { get; set; }
    [DataMember]
    public Nullable<int> ExpenseID { get; set; }
    [DataMember]
    public decimal Hours { get; set; }
    [DataMember]
    public virtual ExpenseDAO Expense { get; set; }
    [DataMember]
    public virtual JobDAO Job { get; set; }
  }
}