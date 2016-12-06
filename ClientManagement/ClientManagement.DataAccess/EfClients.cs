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
  }
}
