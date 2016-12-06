using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientManagement.DbService.Models
{
  public class JobDAO
  {
    public int Id { get; set; }
    public int ServiceTypeID { get; set; }
    public int ClientID { get; set; }
    public string UserID { get; set; }
    public Nullable<System.DateTime> StartDate { get; set; }
    public Nullable<int> EstimatedDuration { get; set; }
    public string Notes { get; set; }
    public bool Complete { get; set; }

    public virtual UserDAO User { get; set; }
    public virtual ClientDAO Client { get; set; }
    public virtual ServiceTypeDAO ServiceType { get; set; }
  }
}