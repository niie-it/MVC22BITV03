using System.ComponentModel.DataAnnotations;

namespace Lab03.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, double.MaxValue, ErrorMessage ="Giá phải lớn hơn 0")]
        public double? Price { get; set; }
        public string Image { get; set; }
    }
}
