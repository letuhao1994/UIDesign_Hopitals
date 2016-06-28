using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLogicLayer;
using DataTransferLayer.Locations;
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

        private void DisplayForRating(List<LocationDto> locations, List<HomepageViewModel> items)
        {
            if(locations == null || items == null) return;

            LocationBlo.Sort(locations, SortOption.Rating, false);

            int count = 0;
            foreach (var location in locations)
            {
                HomepageViewModel hvm = new HomepageViewModel
                {
                    Id = location.Id,
                    Name = location.Name,
                    Rating = location.Rating,
                    Area1 = location.Area1,
                    Area2 = location.Area2
                };

                if (location.Specialists.Count > 0)
                {
                    hvm.Specialist = location.Specialists[0];
                }

                items.Add(hvm);
                count++;

                if (count == 15)
                {
                    break;
                }
            }
        }

        private void DisplayForArea1(List<LocationDto> locations, string area1, 
            List<HomepageViewModel> items)
        {
            if (locations == null || items == null) return;

            List<LocationDto> exists;
            if (string.IsNullOrEmpty(area1))
            {
                exists = locations.Where(x => x.Area1 == "Hà Nội").ToList();
            }
            else
            {
                exists = locations.Where(x => x.Area1 == area1).ToList();            
            }
            LocationBlo.Sort(exists, SortOption.Rating, false);

            int count = 0;
            foreach (var location in exists)
            {
                HomepageViewModel hvm = new HomepageViewModel
                {
                    Id = location.Id,
                    Name = location.Name,
                    Rating = location.Rating,
                    Area1 = location.Area1,
                    Area2 = location.Area2
                };

                if (location.Specialists.Count > 0)
                {
                    hvm.Specialist = location.Specialists[0];
                }

                items.Add(hvm);
                count++;

                if (count == 15)
                {
                    break;
                }
            }
        }

        private void DisplayForArea2(List<LocationDto> locations, string area1, string area2,
            List<HomepageViewModel> items)
        {
            if (locations == null || items == null) return;

            List<LocationDto> exists;
            if (string.IsNullOrEmpty(area1))
            {
                exists = locations.Where(x => x.Area1 == "Hà Nội" && x.Area2 == "Cầu Giấy").ToList();
            }
            else
            {
                exists = locations.Where(x => x.Area1 == area1 && x.Area2 == area2).ToList();
            }

            LocationBlo.Sort(exists, SortOption.Rating, false);

            int count = 0;
            foreach (var location in exists)
            {
                HomepageViewModel hvm = new HomepageViewModel
                {
                    Id = location.Id,
                    Name = location.Name,
                    Rating = location.Rating,
                    Area1 = location.Area1,
                    Area2 = location.Area2
                };

                if (location.Specialists.Count > 0)
                {
                    hvm.Specialist = location.Specialists[0];
                }

                items.Add(hvm);
                count++;

                if (count == 15)
                {
                    break;
                }
            }
        }

        private void DisplayForSpecialist(List<LocationDto> locations, string specialist,
            List<HomepageViewModel> items)
        {
            if (locations == null || items == null) return;

            List<LocationDto> exists;
            if (string.IsNullOrEmpty(specialist))
            {
                exists = locations.Where(x => x.Exists("Chấn thương chỉnh hình")).ToList();
            }
            else
            {
                exists = locations.Where(x => x.Exists(specialist)).ToList();
            }
            LocationBlo.Sort(exists, SortOption.Rating, false);

            int count = 0;
            foreach (var location in exists)
            {
                HomepageViewModel hvm = new HomepageViewModel
                {
                    Id = location.Id,
                    Name = location.Name,
                    Rating = location.Rating,
                    Area1 = location.Area1,
                    Area2 = location.Area2
                };

                if (location.Specialists.Count > 0)
                {
                    hvm.Specialist = location.Specialists[0];
                }

                items.Add(hvm);
                count++;

                if (count == 15)
                {
                    break;
                }
            }
        }

        public ActionResult Home(string tab, string tab2, string tab3)
        {
            var model = new HomeViewModel() {Items = new List<HomepageViewModel>()};
            string path = AppDomain.CurrentDomain.BaseDirectory;
            var locations = LocationBlo.GetLocations2(path);

            switch (tab)
            {
                case "rating":
                    model.TabValue = "rating";
                    model.ListTitle = "Danh sách 15 bệnh viện nổi bật theo đánh giá của người dùng";
                    DisplayForRating(locations, model.Items);
                    break;
                case "area1":
                    model.TabValue = "area1";
                    model.ListTitle = "Danh sách các bệnh viện nổi bật theo tỉnh, thành phố";
                    model.TabValueLvl2 = tab2;
                    DisplayForArea1(locations, tab2, model.Items);
                    break;
                case "area2":
                    model.TabValue = "area2";
                    model.ListTitle = "Danh sách các bệnh viện nổi bật theo quận, huyện";
                    model.TabValueLvl2 = tab2;
                    model.TabValueLvl3 = tab3;
                    DisplayForArea2(locations, tab2, tab3, model.Items);
                    break;
                case "specialist":
                    model.TabValue = "specialist";
                    model.ListTitle = "Danh sách các bệnh viện nổi bật theo chuyên khoa";
                    model.TabValueLvl2 = tab2;
                    DisplayForSpecialist(locations, tab2, model.Items);
                    break;
                default:
                    model.TabValue = "rating";
                    model.ListTitle = "Danh sách 15 bệnh viện nổi bật theo đánh giá của người dùng";
                    DisplayForRating(locations, model.Items);
                    break;
            }           

            return View(model);
        }
    }
}