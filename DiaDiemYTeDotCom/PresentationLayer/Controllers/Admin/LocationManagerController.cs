using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using BusinessLogicLayer;
using DataTransferLayer.Locations;
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

            var locations = LocationBlo.GetLocations2(AppDomain.CurrentDomain.BaseDirectory);
            foreach (var item in locations)
            {
                var location = new LocationUpdateModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    PhoneNumbers = item.PhoneNumbers,
                    FaxNumbers = item.FaxNumbers,
                    LocationType = item.LocationType,
                    Specialists = LocationDto.SpecialistsToString(item.Specialists),
                    Rating = item.Rating.ToString(CultureInfo.CurrentCulture),
                    Area1 = item.Area1,
                    Area2 = item.Area2,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude
                };

                models.Add(location);
            }

            return View(models);
        }

        public ActionResult Details(string id)
        {
            var model = new LocationUpdateModel();
            var locations = LocationBlo.GetLocations2(AppDomain.CurrentDomain.BaseDirectory);

            var exists = locations.Where(x => x.Id == id).ToList();
            if (exists.Count > 0)
            {
                var item = exists[0];
                model = new LocationUpdateModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    PhoneNumbers = item.PhoneNumbers,
                    FaxNumbers = item.FaxNumbers,
                    LocationType = item.LocationType,
                    Specialists = LocationDto.SpecialistsToString(item.Specialists),
                    Rating = item.Rating.ToString(CultureInfo.CurrentCulture),
                    Area1 = item.Area1,
                    Area2 = item.Area2,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude
                };
            }

            return View(model);
        }

        public ActionResult Create(LocationUpdateModel model)
        {
            if (model == null)
            {
                model = new LocationUpdateModel();
            }
            else
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    var item = model;
                    var location = new LocationDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Address = item.Address,
                        PhoneNumbers = item.PhoneNumbers,
                        FaxNumbers = item.FaxNumbers,
                        LocationType = item.LocationType,
                        Specialists = LocationDto.ParseSpecialists(item.Specialists),
                        Rating = 0,
                        Area1 = item.Area1,
                        Area2 = item.Area2,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude
                    };

                    double temp;
                    if (double.TryParse(item.Rating, out temp)) location.Rating = temp;

                    LocationBlo.Add(AppDomain.CurrentDomain.BaseDirectory, location);
                }               
            }

            return View(model);
        }

        public ActionResult Edit(LocationUpdateModel model, string id)
        {
            if(model == null) model = new LocationUpdateModel();

            if(!string.IsNullOrEmpty(id))
            {
                var locations = LocationBlo.GetLocations2(AppDomain.CurrentDomain.BaseDirectory);

                var exists = locations.Where(x => x.Id == id).ToList();
                if (exists.Count > 0)
                {
                    var item = exists[0];
                    model = new LocationUpdateModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Address = item.Address,
                        PhoneNumbers = item.PhoneNumbers,
                        FaxNumbers = item.FaxNumbers,
                        LocationType = item.LocationType,
                        Specialists = LocationDto.SpecialistsToString(item.Specialists),
                        Rating = item.Rating.ToString(CultureInfo.CurrentCulture),
                        Area1 = item.Area1,
                        Area2 = item.Area2,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude
                    };
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    var item = model;
                    var location = new LocationDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Address = item.Address,
                        PhoneNumbers = item.PhoneNumbers,
                        FaxNumbers = item.FaxNumbers,
                        LocationType = item.LocationType,
                        Specialists = LocationDto.ParseSpecialists(item.Specialists),
                        Rating = 0,
                        Area1 = item.Area1,
                        Area2 = item.Area2,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude
                    };

                    double temp;
                    if (double.TryParse(item.Rating, out temp)) location.Rating = temp;

                    LocationBlo.Update(AppDomain.CurrentDomain.BaseDirectory, location);
                }
            }

            return View(model);
        }

        public ActionResult Delete(string id)
        {
            var model = new LocationUpdateModel();

            if (!string.IsNullOrEmpty(id))
            {
                var locations = LocationBlo.GetLocations2(AppDomain.CurrentDomain.BaseDirectory);

                var exists = locations.Where(x => x.Id == id).ToList();
                if (exists.Count > 0)
                {
                    LocationBlo.Delete(AppDomain.CurrentDomain.BaseDirectory, id);

                    var item = exists[0];
                    model = new LocationUpdateModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Address = item.Address,
                        PhoneNumbers = item.PhoneNumbers,
                        FaxNumbers = item.FaxNumbers,
                        LocationType = item.LocationType,
                        Specialists = LocationDto.SpecialistsToString(item.Specialists),
                        Rating = item.Rating.ToString(CultureInfo.CurrentCulture),
                        Area1 = item.Area1,
                        Area2 = item.Area2,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude
                    };
                }
            }

            return View(model);
        }
    }
}
