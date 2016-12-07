using ClientManagement.DataAccess;
using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientManagement.DbService
{
  public class ClientMapper
  {
    public static ClientDAO MapToClientDAO(Client client)
    {
      var c = new ClientDAO();
      
      c.Id = client.Id;
      c.Name = client.Name;
      c.AddressID = client.AddressID;
      c.Address = AddressMapper.MapToAddressDAO(client.Address);
      c.Email = client.Email;
      c.PhoneNumber = client.PhoneNumber;
      c.UserId = client.UserId;
      return c;
    }

    public static Client MapToClient(ClientDAO client)
    {
      var c = new Client();
      c.Id = client.Id;
      c.Name = client.Name;
      c.AddressID = client.AddressID;
      c.Address = AddressMapper.MapToAddress(client.Address);
      c.Email = client.Email;
      c.PhoneNumber = client.PhoneNumber;
      c.UserId = client.UserId;
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