using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreLab.Models
{
	[Table("HangHoa")]
	public class HangHoa
	{
		[Key]
		public int MaHh { get; set; }
		[MaxLength(100)]
		public string TenHh { get; set; }
		public string? MoTa { get; set; }
		[MaxLength(250)]
		public string? Hinh { get; set; }

		public int? MaLoai { get; set; }

		[ForeignKey("MaLoai")]
		public Loai? Loai { get; set; }
	}
}
