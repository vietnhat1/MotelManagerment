using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MotelManagerment
{
    internal class Logger
    {
        private static readonly string userLogPath = "user.log";

        public static void LogGuestActivity(Room room)
        {
            string logEntry = $"[{DateTime.Now}] Room {room.RoomNumber} | Guest: {room.Occupant.Name} | Check-in: {room.Occupant.CheckInTime} | Check-out: {room.Occupant.CheckOutTime}\n";
            File.AppendAllText(userLogPath, logEntry);
        }
    }
}
