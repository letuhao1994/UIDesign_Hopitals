using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogicLayer;
using DataTransferLayer.Locations;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string txtSearch, string ddlSearchOptions)
        {
            var model = new SearchViewModel
            {
                SearchValue = txtSearch,
                Locations = new List<SearchLocationViewModel>()
            };

            string path = AppDomain.CurrentDomain.BaseDirectory;
            List<LocationDto> locations = LocationBlo.GetLocations2(path);

            if(!string.IsNullOrEmpty(txtSearch))
            {
                switch (ddlSearchOptions)
                {
                    case "Name":
                        locations = LocationBlo.Search(locations, SearchOption.Name, txtSearch);
                        break;

                    case "Specialist":
                        locations = LocationBlo.Search(locations, SearchOption.Specialist, txtSearch);
                        break;

                    case "Address":
                        locations = LocationBlo.Search(locations, SearchOption.Address, txtSearch);
                        break;
                }
            }

            LocationBlo.Sort(locations, SortOption.SpectialistAndName, true);

            if (locations != null)
            {
                foreach (var location in locations)
                {
                    SearchLocationViewModel slvm = new SearchLocationViewModel
                    {
                        Id = location.Id,
                        Name = location.Name,
                        Address = location.Address,
                        Rating = location.Rating
                    };

                    if (location.Specialists.Count > 1)
                    {
                        for (int i = 0; i < location.Specialists.Count - 1; i++)
                        {
                            slvm.Specialists += location.Specialists[i] + "; ";
                        }

                        slvm.Specialists += location.Specialists[location.Specialists.Count - 1];
                    }
                    else if (location.Specialists.Count == 1)
                    {
                        slvm.Specialists = location.Specialists[0];
                    }

                    model.Locations.Add(slvm);
                }
            }            

            return View(model);
        }

        public ActionResult ViewOnMaps(string id, string txtSearch, string txtPlaceId)
        {
            ViewOnMapsViewModel model = new ViewOnMapsViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                List<LocationDto> locations = LocationBlo.GetLocations2(path);
                model.Id = id;

                var results = LocationBlo.Search(locations, SearchOption.Id, id);
                if (results.Count > 0)
                {
                    model.UrlSource = "https://www.google.com/maps/embed/v1/place?"
                        + "key=AIzaSyCXu7DK2qiuIyb1tmiHUNemOwY3DTfTP18"
                        + "&q=" + results[0].Address.Replace(" ", "+")
                        + "&language=vi";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearch))
                {
                    model.UrlSource = "https://www.google.com/maps/embed/v1/place?"
                        + "key=AIzaSyCXu7DK2qiuIyb1tmiHUNemOwY3DTfTP18"
                        + "&q=" + txtSearch
                        + "&language=vi";
                    model.SearchValue = txtSearch;

                    if (!string.IsNullOrEmpty(txtPlaceId))
                    {
                        model.LocationDetails = new LocationDetailsViewModel();
                    }                    
                }
                else
                {
                    model.UrlSource = "https://www.google.com/maps/embed/v1/place?"
                        + "key=AIzaSyCXu7DK2qiuIyb1tmiHUNemOwY3DTfTP18"
                        + "&q=Ho+Chi+Minh,Vietname"
                        + "&language=vi";
                }
            }

            return View(model);
        }

        public ActionResult Details(string id)
        {
            return View(id);
        }
    }
}