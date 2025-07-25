
using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.Models
{
	public class PersonalIdExpireDateAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var currentDate = (DateTime?) value;
			if (currentDate.HasValue && currentDate > DateTime.Now)
			{
				return ValidationResult.Success;
			}
			return new ValidationResult("Invalid expire date");
		}
	}
}