using ClientManagement.DataAccess;
using ClientManagement.DbService;
using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClientManagement.Tests
{
  public class TestService
  {
    
    [Fact]
      public void Test_insertJob()
    {
      var data =  new EfData();
      var client = data.GetClients().Where(c => c.Id == 4).FirstOrDefault();
      var user = data.GetUsers().Where(c => c.Id == "60d9002e-667f-4794-a9dd-670c0ecf56c9").FirstOrDefault();
      var st = data.GetTypes().Where(c => c.Id == 1).FirstOrDefault();

      var client2 = ClientMapper.MapToClientDAO(client);
      var user2 = UserMapper.MapToUserDAO(user);
      var st2 = ServiceTypeMapper.MapToServiceTypeDAO(st);

      var j = new JobDAO();

      j.Client = client2;
      j.User = user2;
      j.ServiceType = st2;

      var actual = AddJob(j);

      Assert.True(actual);
    }

    public bool AddJob(JobDAO job)
    {
      var data = new EfData();
      return data.AddJob(JobMapper.MapToJob(job));
    }
  }
}
