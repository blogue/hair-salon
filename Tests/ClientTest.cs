using Xunit;
using HairSalon.Objects;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class ClientTest
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Client_DatabaseEmpty()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }
  }
}
