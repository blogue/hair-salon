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

  }
}
