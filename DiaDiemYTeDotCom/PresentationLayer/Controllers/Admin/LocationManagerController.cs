using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogicLayer;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers.Admin
{
    public class LocationManagerController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLocations()
        {
            List<LocationUpdateModel> models = new List<LocationUpdateModel>();

            var locations = LocationBlo.GetLocations(AppDomain.CurrentDomain.BaseDirectory + "bin\\Hopitals.txt");
            foreach (var item in locations)
            {
                LocationBlo.Add(AppDomain.CurrentDomain.BaseDirectory, item);
            }

            return View(models);
        }

        public ActionResult Details(int id)
        {
            var model = new LocationUpdateModel();

            return View(model);
        }

        public ActionResult Create(LocationUpdateModel model)
        {
            if(model == null) model = new LocationUpdateModel();

            return View(model);
        }

        public ActionResult Edit(LocationUpdateModel model)
        {
            if(model == null) model = new LocationUpdateModel();

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new LocationUpdateModel();
            return View(model);
        }
    }
}
