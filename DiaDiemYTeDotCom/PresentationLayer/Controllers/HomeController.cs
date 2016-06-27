using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogicLayer;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            List<HomepageViewModel> items = new List<HomepageViewModel>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "bin\\Hopitals.txt";
            var locations = LocationBlo.GetLocations(path);
            LocationBlo.Sort(locations, SortOption.Rating, false);

            int count = 0;
            foreach (var location in locations)
            {
                HomepageViewModel hvm = new HomepageViewModel
                {
                    Id = location.Id,
                    Name = location.Name,
                    Rating = location.Rating
                };

                if (location.Specialists.Count > 0)
                {
                    hvm.Specialist = location.Specialists[0];
                }

                items.Add(hvm);
                count++;

                if (count == 10)
                {
                    break;
                }
            }

            return View(items);
        }
    }
}