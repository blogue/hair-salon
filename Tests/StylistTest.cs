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
      //Arrange, Act
      Stylist testStylist = new Stylist("Johnny");
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];
      //Assert
      Assert.Equal(testStylist, savedStylist);

    }
  }
}
