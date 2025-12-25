using System.ComponentModel.DataAnnotations;

namespace UI_MVC._Framework
{
    public class BigCityAttribute : ValidationAttribute
    {
        public BigCityAttribute(string cityNames)
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var v = value.ToString();
            if(
                v == "Tehran" ||
                v=="Shiraz" ||
                v=="Mashhad"
               )
                return new ValidationResult("کاربر نمیتواند عضو شهرهای شلوغ باشد");


            return ValidationResult.Success;
        }
    }
}
