using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClientManagement.DbService
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface IService1
  {

    [OperationContract]
    bool Register(UserDAO user);

    [OperationContract]
    List<UserDAO> GetUsers();

    [OperationContract]
    bool ChangePassword(UserDAO user);

    [OperationContract]
    bool Login(UserDAO user);

    [OperationContract]
    List<ClientDAO> GetClients();

    [OperationContract]
    List<AddressDAO> GetAddress();

    [OperationContract]
    bool AddClient(ClientDAO client);

    [OperationContract]
    bool UpdateClient(ClientDAO client);

    [OperationContract]
    bool DeleteClient(ClientDAO client);

    [OperationContract]
    bool UpdateUser(UserDAO user);

    [OperationContract]
    bool AddType(ServiceTypeDAO service);

    [OperationContract]
    bool UpdateType(ServiceTypeDAO service);

    [OperationContract]
    List<ServiceTypeDAO> GetTypes();

    [OperationContract]
    bool DeleteType(ServiceTypeDAO service);

    [OperationContract]
    bool AddJob(JobDAO job);

    [OperationContract]
    bool UpdateJob(JobDAO job);

    [OperationContract]
    List<JobDAO> GetJobs();

    [OperationContract]
    bool DeleteJob(JobDAO job);
  }
}
