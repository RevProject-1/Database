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

    [Fact]
    public void Test_Register()
    {
      var data = new EfData();
      var expected = new AspNetUser
      {
        Id = "djkfhieur55-3i3kj-kkl",
        Email = "test6@test.com",
        EmailConfirmed = true,
        Name = "Fred",
        StreetAddress = "123 Here",
        City = "Reston",
        State = "VA",
        Zip = "20190",
        PhoneNumber = "1234567890",
        AccessFailedCount = 0,
        LockoutEnabled = false,
        PasswordHash = "ddddddddddddddddddddd",
        SecurityStamp = null,
        TwoFactorEnabled = false,
        PhoneNumberConfirmed = false,
        LockoutEndDateUtc = null,
        UserName = "test6@test.com"
      };
      var actual = data.AddUser(expected);

      Assert.True(actual);
    }

    [Fact]
    public void Test_AddJob()
    {
      var data = new EfData();
      var client = data.GetClients().Where(c => c.Id == 1).FirstOrDefault();
      var user = data.GetUsers().Where(c => c.Id == "kjdfhdakvdalvbjn").FirstOrDefault();
      var st = data.GetTypes().Where(c => c.Id == 2).FirstOrDefault();

      var expected = new ScheduleJob {
        ServiceTypeID = 2,
        ServiceType = st,
        ClientID = 1,
        Client = client,
        UserID = "kjdfhdakvdalvbjn",
        AspNetUser = user,
        StartDate = DateTime.Now,
        EstimatedDuration = 12,
        Notes = "dkjhdjfdadre",
        Complete = false };
      var actual = data.AddJob(expected);
      Assert.True(actual);
    }

    [Fact]
    public void Test_UpdateJob()
    {
      var data = new EfData();
      var client = data.GetClients().Where(c => c.Id == 1).FirstOrDefault();
      var user = data.GetUsers().Where(c => c.Id == "kjdfhdakvdalvbjn").FirstOrDefault();
      var st = data.GetTypes().Where(c => c.Id == 2).FirstOrDefault();

      var expected = new ScheduleJob
      {
        ServiceTypeID = 2,
        ServiceType = st,
        ClientID = 1,
        Client = client,
        UserID = "kjdfhdakvdalvbjn",
        AspNetUser = user,
        StartDate = DateTime.Now,
        EstimatedDuration = 12,
        Notes = "dkjhdjfdadre",
        Complete = false
      };
      var inserted = data.AddJob(expected);
      var job = data.GetJobs().Where(x => x.Id == data.GetJobs().Max(a => a.Id) ).FirstOrDefault();
      expected = job;
      expected.EstimatedDuration = 2;
      var actual = data.UpdateJob(expected);
      
      Assert.True(actual);
    }
  }
}
