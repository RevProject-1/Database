using ClientManagement.DataAccess;
using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientManagement.DbService
{
  public class JobMapper
  {

    public static JobDAO MapToJobDAO(ScheduleJob job)
    {
      var c = new JobDAO();
      c.Id = job.Id;
      c.ServiceTypeID = job.ServiceTypeID;
      c.ServiceType = ServiceTypeMapper.MapToServiceTypeDAO(job.ServiceType);
      c.ClientID = job.ClientID;
      c.Client = ClientMapper.MapToClientDAO(job.Client);
      c.UserID = job.UserID;
      c.User = UserMapper.MapToUserDAO(job.AspNetUser);
      c.StartDate = job.StartDate;
      c.EstimatedDuration = job.EstimatedDuration;
      c.Notes = job.Notes;
      c.ExpenseID = job.ExpenseID;      
      c.Complete = job.Complete;

      return c;
    }

    public static ScheduleJob MapToJob(JobDAO job)
    {
      var c = new ScheduleJob();
      c.Id = job.Id;
      c.ServiceTypeID = job.ServiceTypeID;
      c.ServiceType = ServiceTypeMapper.MapToServiceType(job.ServiceType);
      c.ClientID = job.ClientID;
      c.Client = ClientMapper.MapToClient(job.Client);
      c.UserID = job.UserID;
      c.AspNetUser = UserMapper.MapToUser(job.User);
      c.StartDate = job.StartDate;
      c.EstimatedDuration = job.EstimatedDuration;
      c.Notes = job.Notes;
      c.Complete = job.Complete;

      return c;
    }


    // this is an example of "Reflection"
    public static object MapTo(object o)
    {
      var properties = o.GetType().GetProperties();
      var ob = new object();

      foreach (var item in properties.ToList())
      {
        ob.GetType().GetProperty(item.Name).SetValue(ob, item.GetValue(item));
      }
      return ob;
    }

  }
}

