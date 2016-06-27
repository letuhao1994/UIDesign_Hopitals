using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class LocationUpdateModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumbers { get; set; }

        [Display(Name = "Số fax")]
        public string FaxNumbers { get; set; }

        [Display(Name = "Loại địa điểm")]
        public string LocationType { get; set; }

        [Display(Name = "Chuyên khoa")]
        public string Specialists { get; set; }

        [Display(Name = "Đánh giá")]
        public string Rating { get; set; }

        [Display(Name = "Khu vực 1")]
        public string Area1 { get; set; }

        [Display(Name = "Khu vực 2")]
        public string Area2 { get; set; }

        [Display(Name = "Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude")]
        public double Longitude { get; set; }
    }
}