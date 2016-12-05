using ClientManagement.DataAccess;
using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientManagement.DbService
{
  public class AddressMapper
  {
    public static AddressDAO MapToAddressDAO(Address address)
    {
      var c = new AddressDAO();
      c.Id = address.Id;
      c.Street = address.Street;
      c.City = address.City;
      c.State = address.State;
      c.Zip = address.Zip;
      
      return c;
    }

    public static Address MapToAddress(AddressDAO address)
    {
      var c = new Address();
      c.Id = address.Id;
      c.Street = address.Street;
      c.City = address.City;
      c.State = address.State;
      c.Zip = address.Zip;

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