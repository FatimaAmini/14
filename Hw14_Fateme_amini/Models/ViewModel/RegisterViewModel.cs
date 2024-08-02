using Hw14_Fateme_amini.Extensions;
using Hw14_Fateme_amini.Models.Enums;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Hw14_Fateme_amini.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(3),MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [UserDateOfBirthValidation]
        public DateTime Birthday { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [Range(1,999)]
        public short CourseCode { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
