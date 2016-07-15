using Xunit;
using HairSalon.Objects;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }

    [Fact]
    public void Stylist_DatabaseEmpty_0()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Stylist_EqualStylists_True()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Johnny");
      Stylist secondStylist = new Stylist("Johnny");
      //Assert
      Assert.Equal(firstStylist, secondStylist);
    }

    [Fact]
    public void Stylist_SaveStylistToDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Johnny");
      //Act
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];
      //Assert
      Assert.Equal(testStylist, savedStylist);
    }

    [Fact]
    public void Stylist_SaveStylistWithId()
    {
      //Arrange
      Stylist newStylist = new Stylist("Johnny");
      //Act
      newStylist.Save();
      int result = Stylist.GetAll()[0].GetId();
      int expectedResult = newStylist.GetId();
      //Assert
      Assert.Equal(result, expectedResult);
    }
    [Fact] public void Stylist_FindStylist()
    {
      //Arrange
      Stylist newStylist = new Stylist("Johnny");
      //Act
      newStylist.Save();
      Stylist foundStylist = Stylist.Find(newStylist.GetId());
      //Assert
      Assert.Equal(newStylist, foundStylist);
    }
    [Fact] public void Stylist_Update()
    {
      //Arrange
      Stylist newStylist = new Stylist("Harry");
      newStylist.Save();
      string expectedName = "Johnny";
      //Act
      newStylist.Update("Johnny");
      string actualName = newStylist.GetName();
      //Assert
      Assert.Equal(expectedName, actualName);
    }
    
  }
}
