using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.DataAccess
{
  public partial class EfData
  {

    public List<Address>GetAddress()
    {
      return db.Addresses.ToList();
    }

    public bool AddAddress(Address address)
    {
      var a = new Address();
      a.Street = address.Street;
      a.City = address.City;
      a.State = address.State;
      a.Zip = address.Zip;
      db.Addresses.Add(a);
      return db.SaveChanges() > 0;
    }
  }
}
