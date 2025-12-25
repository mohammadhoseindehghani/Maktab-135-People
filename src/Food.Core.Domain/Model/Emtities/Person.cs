using System.ComponentModel.DataAnnotations;
using UI_MVC._Framework;

namespace UI_MVC.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "فیلد نام اجباری است")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        //[DataType(DataType.Password)]
        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; } = string.Empty;


        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "نام شهر اجبرای می باشد")]
        [MinLength(3,ErrorMessage = "نام شهر باید حداقل 3 کاراکتر باشد")]
        [BigCity(cityNames:"tehran,shiraz")]
        public string CityName { get; set; }

        [Range(18,200)]
        [Display(Name = "سن")]
        public int Age { get; set; }
        
        

        //[Url]
        //public string Website { get; set; }

        //[EmailAddress]
        //public string Email { get; set; }

        //[CreditCard]
        //public string CreditCard { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string Passowrd{ get; set; }

        //public string CityId { get; set; }


        //public bool IsValid()
        //{
        //    if (Age <= 0 || Age > 200)
        //    {
        //        return false;
        //    }

        //    return true;
        //}


    }
}
