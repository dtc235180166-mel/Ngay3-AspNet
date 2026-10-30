namespace Ngay3_PhamTienThanh.Models
{
    public class Product
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int price { get; set; }
        public string? description { get; set; }
        public int categoryId { get; set; }
        public Category? category { get; set; }
    }
}
