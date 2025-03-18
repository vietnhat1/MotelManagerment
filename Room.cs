using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelManagerment
{
    internal class Room
    {
        public int RoomNumber { get; set; }
        public bool IsOccupied { get; set; }
        public double PricePerHour { get; set; } = 10000;
        public Guest Occupant { get; set; } 

        public Guest Guests { get; set; }
        public DateTime CheckOutTime { get; internal set; }
        public DateTime CheckInTime { get; internal set; }
        public bool IsCleaning { get; set; } = false;

        public string GetRoomInfo()
        {
            if (IsOccupied && Occupant != null)
            {
                return $"Phong {RoomNumber} - Dang co khach: {Occupant.Name} (Check-in: {Occupant.CheckInTime})";
            }
            return $"Phong {RoomNumber} - Trong";
        }
    }
}
