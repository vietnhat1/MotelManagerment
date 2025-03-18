using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelManagerment
{
    class Guest
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; } 

        
        public Guest(string name, string gender, int age, DateTime checkInTime, DateTime checkOutTime)
        {
            Name = name;
            Gender = gender;
            Age = age;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
        }

        public Guest()
        {
        }

        public TimeSpan GetStayDuration()
        {
            return (CheckOutTime ?? DateTime.Now) - CheckInTime;
        }

        public string GetGuestInfo()
        {
            string checkOutInfo = CheckOutTime.HasValue ? CheckOutTime.Value.ToString() : "Chua Check-out";
            return $"Ten: {Name}, Gioi tinh: {Gender}, Tuoi: {Age}, Check-in: {CheckInTime}, Check-out: {checkOutInfo}";
        }


        public void CalculateStayDuration()
        {
            if (!CheckOutTime.HasValue)
            {
                CheckOutTime = DateTime.Now;
            }
            Console.WriteLine($"Khach {Name} da luu tru {GetStayDuration().TotalHours:F1} gio.");
        }
    }

   
}
