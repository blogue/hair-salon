using Xunit;
using HairSalon.Objects;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }

    [Fact]
    public void Client_DatabaseEmpty()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Client_ClientEquality()
    {
      //Arrange, Act
      Client firstClient = new Client("Frank", 1);
      Client secondClient = new Client("Frank", 1);
      //Assert
      Assert.Equal(firstClient, secondClient);
    }
  }
}
