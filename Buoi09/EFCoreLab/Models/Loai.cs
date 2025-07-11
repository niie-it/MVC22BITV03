using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreLab.Models
{
	[Table("Loai")]
	public class Loai
	{
		[Key]
		public int MaLoai { get; set; }

		[MaxLength(100)]
		public string TenLoai { get; set; }

		public string? MoTa { get; set; }

		[MaxLength(150)]
		public string? Hinh { get; set; }
	}
}
