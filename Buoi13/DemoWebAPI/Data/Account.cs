using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebAPI.Data
{
	[Table("Account")]
	public class Account
	{
		[Key]
		public string AccountNumber { get; set; }
		public string AccountHolder { get; set; }
		public string Phone { get; set; }
		[Length(12, 12, ErrorMessage ="Extract 12 characters")]
		public string CitizenId { get; set; }
		public DateTime ExpireDate { get; set; }
		public double Balance { get; set; }

	}
}
