using ClientManagement.DataAccess;
using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientManagement.DbService
{
  public class ExpenseMapper
  {
    public static ExpenseDAO MapToExpenseDAO(Expense expense)
    {
      var c = new ExpenseDAO();
      c.Id = expense.Id;
      c.Name = expense.Name;
      c.Cost = expense.Cost;
     
      return c;
    }

    public static Expense MapToExpense(ExpenseDAO expense)
    {
      var c = new Expense();
      c.Id = expense.Id;
      c.Name = expense.Name;
      c.Cost = expense.Cost;
      
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