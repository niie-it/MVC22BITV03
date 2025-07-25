using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.Models
{
	public class RegisterAccount
	{
		public string AccountNumber { get; set; }
		public string AccountHolder { get; set; }
		public string Phone { get; set; }
		[RegularExpression(@"\d{12}")]
		public string CitizenId { get; set; }
		[PersonalIdExpireDate]
		public DateTime ExpiryDate { get; set; }

		[Range(100000, double.MaxValue)]
		public double InitialBalance { get; set; }
	}
}
