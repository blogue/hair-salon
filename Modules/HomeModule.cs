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
        Stylist foundStylist = Stylist.Find(parameters.id);
        return View["view_stylist.cshtml", foundStylist];
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
    }
  }
}
