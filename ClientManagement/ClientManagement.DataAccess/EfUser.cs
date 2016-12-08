using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.DataAccess
{
  public partial class EfData
  {
    public List<AspNetUser> GetUsers()
    {
      return db.AspNetUsers.ToList();
    }

    public bool Login(AspNetUser user)
    {
      var u = db.AspNetUsers.Where(x => x.Id == user.Id && x.PasswordHash == user.PasswordHash);

      return true;
    }
    public bool AddUser(AspNetUser user)
    {
      var u = new AspNetUser();
      u.Id = user.Id;
      u.Email = user.Email;
      u.Name = user.Name;
      u.EmailConfirmed = user.EmailConfirmed;
      u.PasswordHash = user.PasswordHash;
      u.SecurityStamp = user.SecurityStamp;
      u.PhoneNumber = user.PhoneNumber;
      u.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
      u.TwoFactorEnabled = user.TwoFactorEnabled;
      u.LockoutEndDateUtc = user.LockoutEndDateUtc;
      u.LockoutEnabled = user.LockoutEnabled;
      u.AccessFailedCount = user.AccessFailedCount;
      u.UserName = user.UserName;
      u.StreetAddress = user.StreetAddress;
      u.City = user.City;
      u.State = user.State;
      u.Zip = user.Zip;
      u.AspNetRoles = user.AspNetRoles;
      u.AspNetUserClaims = user.AspNetUserClaims;
      u.AspNetUserLogins = user.AspNetUserLogins;
      db.AspNetUsers.Add(u);
      return db.SaveChanges() > 0;
    }

    public bool ChangePassword(AspNetUser user)
    {
      var result = db.AspNetUsers.SingleOrDefault(x => x.Id == user.Id);
      if (result != null)
      {
        if (user.Id != null)
          result.Id = user.Id;

        if (user.PasswordHash != null)
          result.PasswordHash = user.PasswordHash;
      }
      return db.SaveChanges() > 0;
    }

    public bool UpdateUser(AspNetUser user)
    {
      var result = db.AspNetUsers.SingleOrDefault(x => x.Id == user.Id);
      
      if (result != null)
      {
        if (user.Id != null)
          result.Id = user.Id;

        if (user.Email != null)
          result.Email = user.Email;

        if (user.PhoneNumber != null)
          result.PhoneNumber = user.PhoneNumber;

        if (user.UserName != null)
          result.UserName = user.UserName;

        if (user.EmailConfirmed != true)
          result.EmailConfirmed = user.EmailConfirmed;

        if (user.StreetAddress != null)
          result.StreetAddress = user.StreetAddress;

        if (user.City != null)
          result.City = user.City;

        if (user.State != null)
          result.State = user.State;

        if (user.Zip != null)
          result.Zip = user.Zip;

        if (user.TwoFactorEnabled != false)
          result.TwoFactorEnabled = user.TwoFactorEnabled;

        if (user.LockoutEnabled != false)
          result.LockoutEnabled = user.LockoutEnabled;

        if (user.EmailConfirmed != false)
          result.EmailConfirmed = user.EmailConfirmed;

        if (user.PhoneNumberConfirmed != false)
          result.PhoneNumberConfirmed = user.PhoneNumberConfirmed;

        if (user.SecurityStamp != null)
          result.SecurityStamp = user.SecurityStamp;

        if (user.LockoutEndDateUtc != null)
          result.LockoutEndDateUtc = user.LockoutEndDateUtc;

        if (user.PasswordHash != null)
          result.PasswordHash = user.PasswordHash;
      }
      return db.SaveChanges() > 0;
    }    
  }
}
