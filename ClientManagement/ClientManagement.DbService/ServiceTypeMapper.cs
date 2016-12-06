using ClientManagement.DataAccess;
using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientManagement.DbService
{
  public class ServiceTypeMapper
  {
    public static ServiceTypeDAO MapToServiceTypeDAO(ServiceType service)
    {
      var c = new ServiceTypeDAO();

      c.Id = service.Id;
      c.Name = service.Name;
      c.UserId = service.UserId;      
      return c;
    }

    public static ServiceType MapToServiceType(ServiceTypeDAO service)
    {
      var c = new ServiceType();
      c.Id = service.Id;
      c.Name = service.Name;
      c.UserId = service.UserId;      
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