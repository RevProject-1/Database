using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ClientManagement.DbService.Models;
using ClientManagement.DataAccess;

namespace ClientManagement.DbService
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
  public class Service1 : IService1
  {
    EfData ef = new EfData();

    public List<UserDAO> GetUsers()
    {
      var x = ef.GetUsers();
      var b = new List<UserDAO>();

      foreach (var item in x)
      {
        b.Add(UserMapper.MapToUserDAO(item));
      }
      return b;
    }

    public bool Login(UserDAO user)
    {
      return ef.Login(UserMapper.MapToUser(user));

    }

    public bool ChangePassword(UserDAO user)
    {     
      return ef.ChangePassword(UserMapper.MapToUser(user));
    }

    public bool Register(UserDAO user)
    {     
      return ef.AddUser(UserMapper.MapToUser(user));
    }

    public List<ClientDAO> GetClients()
    {
      var s = new List<ClientDAO>();

      foreach (var client in ef.GetClients())
      {
        s.Add(ClientMapper.MapToClientDAO(client));
      }
      return s;
    }

    public List<AddressDAO> GetAddress()
    {
      var s = new List<AddressDAO>();

      foreach (var address in ef.GetAddress())
      {
        s.Add(AddressMapper.MapToAddressDAO(address));
      }
      return s;
    }

    public bool AddClient(ClientDAO client)
    {
      return ef.AddClient(ClientMapper.MapToClient(client));      
    }

    public bool UpdateClient(ClientDAO client)
    {
      return ef.UpdateClient(ClientMapper.MapToClient(client));
    }

    public bool DeleteClient(ClientDAO client)
    {
      return ef.DeleteClient(ClientMapper.MapToClient(client));
    }

    public bool UpdateUser(UserDAO user)
    {
      return ef.UpdateUser(UserMapper.MapToUser(user));
    }

    public bool AddType(ServiceTypeDAO service)
    {
      return ef.AddType(ServiceTypeMapper.MapToServiceType(service));
    }

    public bool UpdateType(ServiceTypeDAO service)
    {
      return ef.UpdateType(ServiceTypeMapper.MapToServiceType(service));
    }

    public List<ServiceTypeDAO> GetTypes()
    {
      var s = new List<ServiceTypeDAO>();

      foreach (var service in ef.GetTypes())
      {
        s.Add(ServiceTypeMapper.MapToServiceTypeDAO(service));
      }
      return s;
    }

    public bool DeleteType(ServiceTypeDAO service)
    {
      return ef.DeleteType(ServiceTypeMapper.MapToServiceType(service));
    }

    public bool AddJob(JobDAO job)
    {
      return ef.AddJob(JobMapper.MapToJob(job));
    }

    public bool UpdateJob(JobDAO job)
    {                  
      return ef.UpdateJob(JobMapper.MapToJob(job));
    }

    public List<JobDAO> GetJobs()
    {
      var s = new List<JobDAO>();

      foreach (var job in ef.GetJobs())
      {
        s.Add(JobMapper.MapToJobDAO(job));
      }
      return s;
    }

    public bool DeleteJob(JobDAO job)
    {
      return ef.DeleteJob(JobMapper.MapToJob(job));
    }

    public List<ExpenseDAO> GetExpenses()
    {
      var s = new List<ExpenseDAO>();

      foreach (var ex in ef.GetExpenses())
      {
        s.Add(ExpenseMapper.MapToExpenseDAO(ex));
      }
      return s;
    }

    public bool AddExpense(ExpenseDAO ex)
    {
      return ef.AddExpense(ExpenseMapper.MapToExpense(ex));
    }

    public bool UpdateExpense(ExpenseDAO ex)
    {
      return ef.UpdateExpense(ExpenseMapper.MapToExpense(ex));
    }

    public bool DeleteExpense(ExpenseDAO ex)
    {
      return ef.DeleteExpense(ExpenseMapper.MapToExpense(ex));
    }

    public List<JobExpenseDAO> GetJobExpenses()
    {
      var s = new List<JobExpenseDAO>();

      foreach (var ex in ef.GetJobExpenses())
      {
        s.Add(JobExpenseMapper.MapToJobExpenseDAO(ex));
      }
      return s;
    }

    public bool AddJobExpense(JobDAO j, ExpenseDAO ex)
    {
      return ef.AddJobExpense(JobMapper.MapToJob(j), ExpenseMapper.MapToExpense(ex));
    }

    public bool UpdateJobExpense(JobExpenseDAO ex)
    {
      return ef.UpdateJobExpense(JobExpenseMapper.MapToJobExpense(ex));
    }

    public bool DeleteJobExpense(JobExpenseDAO ex)
    {
      return ef.DeleteJobExpense(JobExpenseMapper.MapToJobExpense(ex));
    }
  }
}
