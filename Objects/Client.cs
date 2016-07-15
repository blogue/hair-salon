using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylistId;

    public Client(string name, int stylistId, int Id = 0)
    {
      _name = name;
      _stylistId = stylistId;
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
    public int GetStylistId()
    {
      return _stylistId;
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int newClientId = rdr.GetInt32(0);
        string newClientName = rdr.GetString(1);
        int newClientStylistId = rdr.GetInt32(2);

        Client newClient = new Client(newClientName, newClientStylistId, newClientId);
        allClients.Add(newClient);
      }
      if (rdr != null) rdr.Close();
      if (conn != null) conn.Close();

      return allClients;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool clientIdEquality = _id == newClient.GetId();
        bool clientNameEquality = _name == newClient.GetName();
        bool clientStylistIdEquality = _stylistId == newClient.GetStylistId();
        return (clientNameEquality && clientIdEquality && clientStylistIdEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@NewName, @NewStylistId)", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = _name;
      cmd.Parameters.Add(newNameParameter);

      SqlParameter newStylistIdParameter = new SqlParameter();
      newStylistIdParameter.ParameterName = "@NewStylistId";
      newStylistIdParameter.Value = _stylistId;
      cmd.Parameters.Add(newStylistIdParameter);

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

      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      rdr = cmd.ExecuteReader();
    }

    public static Client Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);

      SqlParameter newIdParameter = new SqlParameter();
      newIdParameter.ParameterName = "@ClientId";
      newIdParameter.Value = id;
      cmd.Parameters.Add(newIdParameter);

      int foundId = 0;
      string foundName = null;
      int foundStylistId = 0;

      rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        foundName = rdr.GetString(1);
        foundStylistId = rdr.GetInt32(2);
      }
      Client foundClient = new Client(foundName, foundStylistId, foundId);

      if (rdr != null) rdr.Close();
      if (conn != null) conn.Close();

      return foundClient;
    }

  }
}
