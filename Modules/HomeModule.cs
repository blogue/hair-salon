using Nancy;
using System;
using System.Collections.Generic;
using HairSalon.Objects;

namespace HairSalon.Objects
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
        Get["/"] = _ => {
        return View["index.cshtml"];
      };
        Get["/stylists"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/stylists/add"] = _ => {
        return View["add_stylist.cshtml"];
      };
      Post["/stylists/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["name"]);
        newStylist.Save();
        return View["success.cshtml", newStylist];
      };
      Get["/stylist/{id}"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View["view_stylist.cshtml", selectedStylist];
      };
      Get["/stylist/edit/{id}"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View["edit_stylist.cshtml", selectedStylist];
      };
      Patch["/stylist/edit/{id}"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Update(Request.Form["name"]);
        return View["success.cshtml", selectedStylist];
      };
      Delete["/stylist/delete/{id}"] = parameters => {
        Stylist.Delete(parameters.id);
        return View["success.cshtml"];
      };
      Get["/stylists/deleted"] = _ => {
        Stylist.DeleteAll();
        return View["success.cshtml"];
      };
      Post["/stylist/new_client"] = _ => {
        Client newClient = new Client(Request.Form["name"], Request.Form["stylistId"]);
        newClient.Save();
        return View["success.cshtml", newClient];
      };
      Get["/client/edit/{id}"] = parameters => {
        Client selectedClient = Client.Find(parameters.id);
        return View["edit_client.cshtml", selectedClient];
      };
      Patch["/client/edit/{id}"] = parameters => {
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Update(Request.Form["name"], Request.Form["stylistId"]);
        return View["success.cshtml", selectedClient];
      };
      Delete["/client/delete/{id}"] = parameters => {
        Client.Delete(parameters.id);
        return View["success.cshtml"];
      };
    }
  }
}
