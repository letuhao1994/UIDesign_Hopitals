using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class SearchViewModel
    {
        public string SearchValue { get; set; }
        public string SearchTypeValue { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Chuyên khoa")]
        public string Specialists { get; set; }

        [Display(Name = "Đánh giá")]
        public double Rating { get; set; }

        public List<SearchLocationViewModel> Locations { get; set; } 
    }

    public class SearchLocationViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Chuyên khoa")]
        public string Specialists { get; set; }

        [Display(Name = "Đánh giá")]
        public double Rating { get; set; }
    }

    public class ViewOnMapsViewModel
    {
        public string Id { get; set; }
        public string UrlSource { get; set; }
        public string SearchValue { get; set; }
        public LocationDetailsViewModel LocationDetails { get; set; }
    }

    public class LocationDetailsViewModel
    {
        public string ImageSource { get; set; }
    }
}
