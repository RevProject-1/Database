using ClientManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClientManagement.Tests
{
  public class EfTests
  {
    [Fact]
    public void Test_InsertClient()
    {
      var data = new EfData();
      var expected = new Client() { Name = "Derek", Address = new Address() {Street = "123 main", City = "Reston", State = "VA", Zip = "20190" }, Email = "test@test.com", PhoneNumber = "1234567890" };

      var actual = data.AddClient(expected);

      Assert.True(actual);
    }

    [Fact]
    public void Test_InsertAddress()
    {
      var data = new EfData();
      var expected = new Address() { Street = "123 main", City = "Reston", State = "VA", Zip = "20190" };
      var actual = data.AddAddress(expected);

      Assert.True(actual);
    }

    [Fact]
    public void Test_GetUserName()
    {
      var data = new EfData();
      var expected = data.GetUsers().ToList();
      Assert.NotEmpty(expected);
    }
  }
}
