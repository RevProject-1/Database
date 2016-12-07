using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.DataAccess
{
  public partial class EfData
  {
    public bool AddJobExpense(ScheduleJob j, Expense e)
    {
      var s = new JobExpense();
      
      s.JobID = j.Id;
      s.ExpenseID = e.Id;

      db.JobExpenses.Add(s);
      return db.SaveChanges() > 0;
    }

    public List<JobExpense> GetJobExpenses()
    {
      return db.JobExpenses.ToList();
    }

    public bool UpdateJobExpense(JobExpense jo)
    {
      var result = db.JobExpenses.SingleOrDefault(x => x.Id == jo.Id);

      if (result != null)
      {
        if (jo.Id != 0)
          result.Id = jo.Id;

        if (jo.JobID != 0)
          result.JobID = jo.JobID;

        if (jo.ExpenseID != 0M)
          result.ExpenseID = jo.ExpenseID;
      }
      return db.SaveChanges() > 0;
    }

    public bool DeleteJobExpense(JobExpense jo)
    {
      var x = db.Expenses.Where(c => c.Id == jo.Id).FirstOrDefault();
      db.Expenses.Remove(x);
      return db.SaveChanges() > 0;
    }
  }

}
