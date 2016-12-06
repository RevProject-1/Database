using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.DataAccess
{
  public partial class EfData
  {
    public List<ServiceType> GetTypes()
    {
      return db.ServiceTypes.ToList();
    }

    public bool AddType(ServiceType service)
    {
      var s = new ServiceType();
      s.Id = service.Id;
      s.Name = service.Name;
      s.UserId = service.UserId;
      db.ServiceTypes.Add(s);
      return db.SaveChanges() > 0;
    }

    public bool UpdateType(ServiceType service)
    {
      var result = db.ServiceTypes.SingleOrDefault(x => x.Id == service.Id);

      if (result != null)
      {
        if (service.Id != 0)
          result.Id = service.Id;

        if (service.Name != null)
          result.Name = service.Name;

        if (service.UserId != null)
          result.UserId = service.UserId;        
      }
      return db.SaveChanges() > 0;
    }

    public bool DeleteType(ServiceType service)
    {
      var x = db.ServiceTypes.Where(c => c.Name == service.Name).FirstOrDefault();
      db.ServiceTypes.Remove(x);
      return db.SaveChanges() > 0;
    }
  }
}
