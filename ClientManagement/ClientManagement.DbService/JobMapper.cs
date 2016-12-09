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
      var ef = new EfData();
      var c = new JobDAO();
      c.Id = job.Id;
      c.ServiceTypeID = job.ServiceTypeID;
      c.ServiceType = ServiceTypeMapper.MapToServiceTypeDAO(job.ServiceType);
      c.ClientID = job.ClientID;
      c.Client = ClientMapper.MapToClientDAO(job.Client);
      c.User = UserMapper.MapToUserDAO(ef.GetUsers().Where(x =>x.Id == job.UserID).FirstOrDefault());
      c.UserID = job.UserID;     
      c.StartDate = job.StartDate;
      c.EndDate = job.EndDate;
      c.EstimatedDuration = job.EstimatedDuration;
      c.Notes = job.Notes;
      c.Hours = job.Hours;       
      c.Complete = job.Complete;

      return c;
    }

    public static ScheduleJob MapToJob(JobDAO job)
    {
      var c = new ScheduleJob();

      c.Id = job.Id;     
      c.ServiceTypeID = job.ServiceType.Id;
      c.ServiceType = ServiceTypeMapper.MapToServiceType(job.ServiceType);
      c.ClientID = job.Client.Id;
      c.Client = ClientMapper.MapToClient(job.Client);
      c.UserID = job.User.Id;
      //c.AspNetUser = UserMapper.MapToUser(job.User);
      c.StartDate = job.StartDate;
      c.EndDate = job.EndDate;
      c.EstimatedDuration = job.EstimatedDuration;
      c.Notes = job.Notes;
      c.Hours = job.Hours;
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

