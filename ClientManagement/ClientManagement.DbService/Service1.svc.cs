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
  }
}
