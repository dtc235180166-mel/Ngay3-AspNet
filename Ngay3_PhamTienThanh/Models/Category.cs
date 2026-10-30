using System.ComponentModel.DataAnnotations;

namespace Ngay3_PhamTienThanh.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Category ID is required")]
       public int id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Tên quá ngoo")] 
        public String? name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
