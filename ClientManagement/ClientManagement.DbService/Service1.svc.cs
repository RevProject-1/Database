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
      //var u = new AspNetUser();
      //u.Id = user.Id;
      //u.Email = user.Email;
      //u.EmailConfirmed = true;
      //u.PasswordHash = user.PasswordHash;
      //u.SecurityStamp = user.SecurityStamp;
      //u.PhoneNumber = user.PhoneNumber;
      //u.PhoneNumberConfirmed = false;
      //u.TwoFactorEnabled = false;
      //u.LockoutEndDateUtc = user.LockoutEndDateUtc;
      //u.LockoutEnabled = false;
      //u.AccessFailedCount = user.AccessFailedCount;
      //u.UserName = user.UserName;
      //u.StreetAddress = user.StreetAddress;
      //u.City = user.City;
      //u.State = user.State;
      //u.Zip = user.Zip;


      //return ef.AddUser(u);
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
  }
}
