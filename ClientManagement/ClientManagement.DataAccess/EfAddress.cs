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
  }
}
