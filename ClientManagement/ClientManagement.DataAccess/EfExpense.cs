using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.DataAccess
{
  public partial class EfData
  {
    public List<Expense> GetExpenses()
    {
      return db.Expenses.ToList();
    }

    public bool AddExpense(Expense ex)
    {
      var s = new Expense();
      s.Id = ex.Id;
      s.Name = ex.Name;
      s.Cost = ex.Cost;
     
      db.Expenses.Add(s);
      return db.SaveChanges() > 0;
    }

    public bool UpdateExpense(Expense ex)
    {
      var result = db.Expenses.SingleOrDefault(x => x.Id == ex.Id);

      if (result != null)
      {
        if (ex.Id != 0)
          result.Id = ex.Id;

        if (ex.Name != null)
          result.Name = ex.Name;

        if (ex.Cost != 0M)
          result.Cost = ex.Cost;       
      }
      return db.SaveChanges() > 0;
    }

    public bool DeleteExpense(Expense ex)
    {
      var x = db.Expenses.Where(c => c.Name == ex.Name).FirstOrDefault();
      db.Expenses.Remove(x);
      return db.SaveChanges() > 0;
    }
  }
}
