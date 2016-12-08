using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.DataAccess
{
  public partial class EfData
  {

    public List<ScheduleJob> GetJobs()
    {
      return db.ScheduleJobs.ToList();
    }

    public bool AddJob(ScheduleJob job)
    {
      var s = new ScheduleJob();

      var x = new EfData();

      
      s.ServiceTypeID = job.ServiceType.Id;
      s.ClientID = x.GetClients().Where(c => c.Name.Equals(job.Client.Name)).FirstOrDefault().Id;
      //s.AspNetUser = job.AspNetUser;
      s.UserID = job.UserID;
      s.StartDate = job.StartDate;
      s.EstimatedDuration = job.EstimatedDuration;
      s.Notes = job.Notes;
      s.Hours = job.Hours;    
      s.Complete = job.Complete;
      db.ScheduleJobs.Add(s);
      return db.SaveChanges() > 0;
    }

    public bool UpdateJob(ScheduleJob job)
    {
      var result = db.ScheduleJobs.SingleOrDefault(x => x.Id == job.Id);
      
      if (result != null)
      {
        if (job.Id != 0)
          result.Id = job.Id;

        if (job.ServiceTypeID != 0)
          result.ServiceTypeID = job.ServiceTypeID;

        if (job.ClientID != 0)
          result.ClientID = job.ClientID;

        if (job.UserID != null)
          result.UserID = job.UserID;

        if (job.StartDate != null)
          result.StartDate = job.StartDate;

        if (job.EstimatedDuration != null)
          result.EstimatedDuration = job.EstimatedDuration;

        if (job.Notes != null)
          result.Notes = job.Notes;

        if (job.Hours != 0)
          result.Hours = job.Hours;

        if (job.Complete != true)
          result.Complete = job.Complete;
      }
      return db.SaveChanges() > 0;
    }

    public bool DeleteJob(ScheduleJob job)
    {
      var x = db.ScheduleJobs.Where(c => c.Id == job.Id).FirstOrDefault();
      db.ScheduleJobs.Remove(x);
      return db.SaveChanges() > 0;
    }
  }
}

