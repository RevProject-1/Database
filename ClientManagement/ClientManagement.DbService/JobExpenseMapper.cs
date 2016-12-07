using ClientManagement.DataAccess;
using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientManagement.DbService
{
  public class JobExpenseMapper
  {
    public static JobExpenseDAO MapToJobExpenseDAO(JobExpense jx)
    {
      var c = new JobExpenseDAO();

      c.Id = jx.Id;
      c.ExpenseID = jx.ExpenseID;
      c.Expense = ExpenseMapper.MapToExpenseDAO(jx.Expense);
      c.JobID = jx.JobID;
      c.Job = JobMapper.MapToJobDAO(jx.ScheduleJob);     
      
      return c;
    }

    public static JobExpense MapToJobExpense(JobExpenseDAO jx)
    {
      var c = new JobExpense();

      c.Id = jx.Id;
      c.ExpenseID = jx.ExpenseID;
      c.Expense = ExpenseMapper.MapToExpense(jx.Expense);
      c.JobID = jx.JobID;
      c.ScheduleJob = JobMapper.MapToJob(jx.Job);

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