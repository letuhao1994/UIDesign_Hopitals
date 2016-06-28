using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class HomeViewModel
    {
        public string TabValue { get; set; }
        public string ListTitle { get; set; }
        public string TabValueLvl2 { get; set; }
        public string TabValueLvl3 { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Display(Name = "Chuyên khoa")]
        public string Specialist { get; set; }
        [Display(Name = "Đánh giá")]
        [DisplayFormat(DataFormatString = "{0:#.#}")]
        public double Rating { get; set; }
        [Display(Name = "Tỉnh, thành phố")]
        public string Area1 { get; set; }
        [Display(Name = "Quận, huyện")]
        public string Area2 { get; set; }
        public List<HomepageViewModel> Items { get; set; } 
    }

    public class HomepageViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Chuyên khoa")]
        public string Specialist { get; set; }

        [Display(Name = "Đánh giá")]
        [DisplayFormat(DataFormatString = "{0:#.#}")]
        public double Rating { get; set; }

        [Display(Name = "Tỉnh, thành phố")]
        public string Area1 { get; set; }

        [Display(Name = "Quận, huyện")]
        public string Area2 { get; set; }
    }
}
