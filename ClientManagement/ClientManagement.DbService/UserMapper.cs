using ClientManagement.DataAccess;
using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientManagement.DbService
{
  public class UserMapper
  {

    public static UserDAO MapToUserDAO(AspNetUser user)
    {
      var u = new UserDAO();
      u.Id = user.Id;
      u.Email = user.Email;
      u.EmailConfirmed = true;
      u.PasswordHash = user.PasswordHash;
      u.SecurityStamp = user.SecurityStamp;
      u.PhoneNumber = user.PhoneNumber;
      u.PhoneNumberConfirmed = false;
      u.TwoFactorEnabled = false;
      u.LockoutEndDateUtc = user.LockoutEndDateUtc;
      u.LockoutEnabled = false;
      u.AccessFailedCount = user.AccessFailedCount;
      u.UserName = user.UserName;
      u.StreetAddress = user.StreetAddress;
      u.City = user.City;
      u.State = user.State;
      u.Zip = user.Zip;

      return u;
    }

    public static AspNetUser MapToUser(UserDAO user)
    {
      var u = new AspNetUser();
      u.Id = user.Id;
      u.Email = user.Email;
      u.EmailConfirmed = true;
      u.PasswordHash = user.PasswordHash;
      u.SecurityStamp = user.SecurityStamp;
      u.PhoneNumber = user.PhoneNumber;
      u.PhoneNumberConfirmed = false;
      u.TwoFactorEnabled = false;
      u.LockoutEndDateUtc = user.LockoutEndDateUtc;
      u.LockoutEnabled = false;
      u.AccessFailedCount = user.AccessFailedCount;
      u.UserName = user.UserName;
      u.StreetAddress = user.StreetAddress;
      u.City = user.City;
      u.State = user.State;
      u.Zip = user.Zip;

      return u;
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