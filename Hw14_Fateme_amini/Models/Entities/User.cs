using Hw14_Fateme_amini.Models.Enums;

namespace Hw14_Fateme_amini.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public short CourseCode { get; set; }
        public Gender Gender { get; set; }
    }
}
