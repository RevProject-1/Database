using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.DataAccess
{
  public partial class EfData
  {
    public List<Client>GetClients()
    {
      return db.Clients.ToList();
    }

    public bool DeleteClient(Client client)
    {
      var x = db.Clients.Where(c => c.Id == client.Id).FirstOrDefault();
      db.Clients.Remove(x);
      return db.SaveChanges() > 0;
    }

    public bool AddClient(Client client)
    { 
      var a = new Address();
      a.Street = client.Address.Street;
      a.City = client.Address.City;
      a.State = client.Address.State;
      a.Zip = client.Address.Zip;
      db.Addresses.Add(a);
      db.SaveChanges();

      var c = new Client();   
      
      c.AddressID = a.Id;
      c.Name = client.Name;
      c.Email = client.Email;
      c.PhoneNumber = client.PhoneNumber;
      c.UserId = client.UserId;
      db.Clients.Add(c);

      return db.SaveChanges() > 0;
    }

    public bool UpdateClient(Client client)
    {
      var result = db.Clients.SingleOrDefault(x => x.Id == client.Id);

      if (result != null)
      {
        if (client.Id != 0)
          result.Id = client.Id;

        if (client.Name != null)
          result.Name = client.Name;

        if (client.Address.Street != null)
          result.Address.Street = client.Address.Street;

        if (client.Address.City != null)
          result.Address.City = client.Address.City;

        if (client.Address.State != null)
          result.Address.State = client.Address.State;

        if (client.Address.Zip != null)
          result.Address.Zip = client.Address.Zip;

        if (client.Email != null)
          result.Email = client.Email;

        if (client.PhoneNumber != null)
          result.PhoneNumber = client.PhoneNumber;
      }
      return db.SaveChanges() > 0;
    }
  }
}
