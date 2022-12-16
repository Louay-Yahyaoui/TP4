using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public long phone_number { get; set; }
        public long timestamp { get; set; }
        public string course { get; set; }
        public string university { get; set; }
    }
}