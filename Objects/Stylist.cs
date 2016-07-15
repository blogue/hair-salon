using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class Stylist
  {
    private int _id;
    private string _name;

    public Stylist(string name, int Id = 0)
    {
      _name = name;
      _id = Id;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int newStylistId = rdr.GetInt32(0);
        string newStylistName = rdr.GetString(1);

        Stylist newStylist = new Stylist(newStylistName, newStylistId);
        allStylists.Add(newStylist);
      }

      if (rdr != null) rdr.Close();
      if (conn != null) conn.Close();

      return allStylists;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool stylistIdEquality = (_id == newStylist.GetId());
        bool stylistNameEquality = (_name == newStylist.GetName());
        return (stylistNameEquality && stylistIdEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;

      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name) OUTPUT INSERTED.id VALUES (@NewName)", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = _name;
      cmd.Parameters.Add(newNameParameter);

      rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        _id = rdr.GetInt32(0);
      }

      if (rdr != null) rdr.Close();
      if (conn != null) conn.Close();
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;

      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      rdr = cmd.ExecuteReader();
    }

  }
}
