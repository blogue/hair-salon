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
    [Fact]
    public void Client_SavesToDataBase()
    {
      //Arrange, Act
      Client newClient = new Client("Samantha", 2);
      newClient.Save();
      string expectedResult = Client.GetAll()[0].GetName();
      string actualResult = "Samantha";
      //Assert
      Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Client_SaveClientWithId()
    {
      //Arrange
      Client newClient = new Client("Johnny", 1);
      //Act
      newClient.Save();
      int result = Client.GetAll()[0].GetId();
      int expectedResult = newClient.GetId();
      //Assert
      Assert.Equal(result, expectedResult);
    }
    [Fact] public void Client_FindClient()
    {
      //Arrange
      Client newClient = new Client("Johnny", 2);
      //Act
      newClient.Save();
      Client foundClient = Client.Find(newClient.GetId());
      //Assert
      Assert.Equal(newClient, foundClient);
    }
    [Fact] public void Client_Update()
    {
      //Arrange
      Client newClient = new Client("Harry", 2);
      newClient.Save();
      string expectedName = "Johnny";
      int expectedStylistId = 1;
      //Act
      newClient.Update("Johnny", 1);
      string actualName = newClient.GetName();
      int actualStylistId = newClient.GetStylistId();
      //Assert
      Assert.Equal(expectedName, actualName);
      Assert.Equal(expectedStylistId, actualStylistId);
    }

    
  }
}
