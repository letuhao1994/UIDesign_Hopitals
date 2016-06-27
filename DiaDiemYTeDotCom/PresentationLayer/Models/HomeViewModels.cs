using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
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
    }
}
