using MotelManagerment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelManagerment
{
    internal class MotelManager
    {
        public List<Room> rooms = new List<Room>();
        public List<Guest> guests = new List<Guest>();

        public MotelManager()
        {
            for (int i = 1; i <= 10; i++)
            {
                Room room = new Room { RoomNumber = i, IsOccupied = i % 2 == 0 };
                if (room.IsOccupied)
                {
                    room.Occupant = new Guest { Name = $"Khách {i}", Gender = "Nam", Age = 25 + i, CheckInTime = DateTime.Now.AddDays(-3), CheckOutTime = DateTime.Now.AddHours(-2) };
                    guests.Add(room.Occupant);
                }
                rooms.Add(room);

            }

        }


        public void DisplayRoomList()
        {
            Console.WriteLine("Danh sach tat ca cac phong:");
            foreach (var room in rooms)
            {
                if (room.IsOccupied)
                {
                    Console.WriteLine($"Room {room.RoomNumber}: Da co nguoi ");
                    Console.WriteLine($"Price: {room.PricePerHour} ");
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine($"Room {room.RoomNumber}: Trong");
                    Console.WriteLine($"Price: {room.PricePerHour}");
                    Console.WriteLine("\n");
                }
            }
        }

        public void DisplayEmptyRooms()
        {
            Console.WriteLine("Danh sach cac phong trong:");
            foreach (var room in rooms)
            {
                if (!room.IsOccupied)
                {
                    Console.WriteLine($"Room {room.RoomNumber}: Trong");
                }
            }
        }

        public void DisplayOccupiedRooms()
        {
            Console.WriteLine("Danh sach cac phong da co khach:");
            foreach (var room in rooms)
            {
                if (room.IsOccupied)
                {
                    Console.WriteLine($"Room {room.RoomNumber}: Da co nguoi");
                    Console.WriteLine("\n");

                }
            }
        }

        public void CheckRoomInfo()
        {
            Console.Write("Nhap so phong can kiem tra: ");
            if (int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Room room = rooms.Find(r => r.RoomNumber == roomNumber);
                if (room != null)
                {
                    Console.WriteLine(room.GetRoomInfo());
                    if (room.IsOccupied && room.Occupant != null)
                    {
                        Console.Write($"Ten khach hang: {room.Occupant.Name}, Gioi tinh: {room.Occupant.Gender}, Tuoi: {room.Occupant.Age} tuoi");
                        Console.WriteLine($"Check-in Time: {room.Occupant.CheckInTime}");
                    }
                }
                else
                {
                    Console.WriteLine("Khong tim thay phong.");
                }
            }
            else
            {
                Console.WriteLine("So phong khong hop le.");
            }

        }
        public void DisplayGuestList()
        {
            foreach (var room in rooms)
            {
                if (room.IsOccupied && room.Occupant != null)
                {
                    Console.WriteLine($"Phong {room.RoomNumber}: Khach thue");
                    Console.WriteLine($"Ten khach hang: {room.Occupant.Name}, Check-in Time: {room.Occupant.CheckInTime}");
                }
                else
                {
                    Console.WriteLine($"Phong {room.RoomNumber}: Trong");
                }
            }
        }
        public void DisplayGuestStayDuration()
        {
            Console.Write("Tat ca khach thue: ");
            Console.WriteLine("\nDanh sach khach hang ra vao");

            foreach (var guest in rooms)
            {
                if (guest.IsOccupied && guest.Occupant != null)
                {
                    Console.WriteLine($"\nRoom {guest.RoomNumber}: Khach thue");
                    Console.WriteLine($"Ten khach hang: {guest.Occupant.Name}, Check-in Time: {guest.Occupant.CheckInTime}, Check-out Time: {guest.Occupant.CheckOutTime}");
                }
            }
        }

        public void LogGuestCheckOut()
        {
            Console.WriteLine("\nThoi gian khach luu tru:");
            foreach (var guest in rooms)
            {
                if (guest.IsOccupied && guest.Occupant != null)
                {
                    Console.WriteLine($"\nRoom {guest.RoomNumber}: Khach thue");
                    Console.WriteLine($"Ten khach hang: {guest.Occupant.Name}");
                    Console.WriteLine($"Gioi tinh: {guest.Occupant.Gender}");
                    Console.WriteLine($"Tuoi: {guest.Occupant.Age}");
                    Console.WriteLine($"Check-in Time: {guest.Occupant.CheckInTime}");
                    Console.WriteLine($"Check-out Time: {guest.Occupant.CheckOutTime}");
                    Console.WriteLine($"Thoi gian luu tru: {(guest.Occupant.CheckOutTime - guest.Occupant.CheckInTime)}");
                    Console.WriteLine("\n");
                }
            }
        }
        public void ModifyPriceRoom()
        {
            Console.Write("Nhap so phong can thay doi gia: ");
            if (int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                if (room != null)
                {
                    Console.Write("Nhap gia moi cho phong (theo gio): ");
                    if (double.TryParse(Console.ReadLine(), out double price))
                    {
                        room.PricePerHour = price;
                        Console.WriteLine($"Gia phong {room.RoomNumber} duoc cap nhat thanh {room.PricePerHour} VND/gio.");
                    }
                    else
                    {
                        Console.WriteLine("Gia khong hop le.");
                    }
                }
                else
                {
                    Console.WriteLine("Phong khong ton tai.");
                }
            }
            else
            {
                Console.WriteLine("So phong khong hop le.");
            }
        }

        public void Bill()
        {
            Console.Write("Nhap so phong can xuat hoa don: ");
            if (int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Room room = rooms.Find(r => r.RoomNumber == roomNumber);
                if (room != null && room.IsOccupied && room.Occupant != null)
                {
                    room.Occupant.CheckOutTime = DateTime.Now;
                    double totalHours = (double)room.Occupant.GetStayDuration().TotalHours;
                    double totalCost = totalHours * room.PricePerHour;

                    string invoice = $"\n=== HOA DON ===\n"
                              + $"Phong so: {room.RoomNumber}\n"
                              + $"Khach hang: {room.Occupant.Name}\n"
                              + $"Gioi tinh: {room.Occupant.Gender}\n"
                              + $"Tuoi: {room.Occupant.Age}\n"
                              + $"Thoi gian nhan phong: {room.Occupant.CheckInTime}\n"
                              + $"Thoi gian tra phong: {room.Occupant.CheckOutTime}\n"
                              + $"Tong thoi gian luu tru: {totalHours:F2} gio\n"
                              + $"Gia phong moi gio: {room.PricePerHour} VND\n"
                              + $"Tong chi phi: {totalCost} VND\n";
                    string time = $"Hoa don phong so: {room.RoomNumber}, khach hang: {room.Occupant.Name}, thoi gian nhan phong: {room.Occupant.CheckInTime}, Thoi gian tra phong: {room.Occupant.CheckOutTime}\n";
                    string bill = $"Hoa don phong so: {room.RoomNumber}, khach hang: {room.Occupant.Name}, tong tine: {totalCost}\n";
                    Console.WriteLine(invoice);
                    //SaveCheckIn(bill);
                    //SaveTime(time);
                    File.WriteAllText($@"D:\Thực tập\hoadon\\HoaDon_Phong{room.RoomNumber}.txt", invoice);

                    Console.WriteLine($"Hoa don da duoc luu vao file: HoaDon_Phong{room.RoomNumber}.txt");
                }
                else
                {
                    Console.WriteLine("Phong khong ton tai hoac chua co khach.");
                }
            }
        }
        public static void LogActivity(string message, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        public static void SaveCheckIn(List<Room> rooms)
        {
            string logPath = "user.log";
            foreach (var room in rooms)
            {
                if (room.IsOccupied)
                {
                    string logEntry = $"Khach {room.Guests.Name} nhan phong {room.RoomNumber} vao luc {room.CheckInTime}";
                    LogActivity(logEntry, logPath);
                }
            }
            Console.WriteLine("Da luu thong tin nhan phong vao user.log.");
        }

        public static void SaveBill(Room room)
        {
            string billLogPath = "bill.log";
            double totalHours = ((DateTime)room.CheckOutTime - (DateTime)room.CheckInTime).TotalHours;
            double totalCost = totalHours * room.PricePerHour;

            string billEntry = $"Hoa don - Phong {room.RoomNumber}: {room.Guests.Name} - {totalHours:F2} gio - Tong tien: {totalCost} VND";
            LogActivity(billEntry, billLogPath);
            Console.WriteLine("Da luu hoa don vao bill.log.");
        }

        public static void UpdateRoomStatus(List<Room> rooms)
        {
            string logPath = "room_status.log";
            foreach (var room in rooms)
            {
                string status = room.IsOccupied ? "Da co nguoi" : "Trong";
                LogActivity($"Phong {room.RoomNumber} doi trang thai: {status}", logPath);
            }
            Console.WriteLine("Da cap nhat trang thai phong vao room_status.log.");
        }
        //public void SaveCheckIn(string time)
        //{
        //    File.AppendAllText(@"D:\Thực tập\hoadon\\user123.log", $" {time}");
        //}

        //public void SaveTime(string bill)
        //{
        //    File.AppendAllText(@"D:\Thực tập\hoadon\\bill.log", $" {bill}");
        //}

        public void NewReservation()
        {
            Console.Write("Nhap so phong can dat truoc: ");
            int roomNumber = int.Parse(Console.ReadLine());

            var room = rooms.Find(r => r.RoomNumber == roomNumber);
            if (room != null && !room.IsOccupied)
            {
                Console.Write("Nhap ten khach hang: ");
                string name = Console.ReadLine();

                Console.Write("Nhap ngay check in (yyyy-MM-dd HH:mm): ");
                DateTime checkInTime = DateTime.Parse(Console.ReadLine());

                Console.Write("Nhap ngay check out (yyyy-MM-dd HH:mm): ");
                DateTime checkOutTime = DateTime.Parse(Console.ReadLine());

                room.Guests = new Guest { Name = name };
                room.CheckInTime = checkInTime;
                room.CheckOutTime = checkOutTime;
                rooms.Add(room);

                Console.WriteLine($"Phong {room.RoomNumber} da dat truoc boi {name} tu {checkInTime} den {checkOutTime}.");
            }
            else
            {
                Console.WriteLine("Phong khong kha dung hoac da co khach.");
            }
        }
        public void ViewReservation()
        {

            Console.WriteLine("\nDanh sach phong dat truoc:");

            foreach (var room in rooms)
            {
                string guestName = room.Guests != null ? room.Guests.Name : "Chua co khach";
                string checkInTime = room.Guests != null ? room.CheckInTime.ToString() : "N/A";
                string checkOutTime = room.Guests != null ? room.CheckOutTime.ToString() : "N/A";

                Console.WriteLine($"Phong {room.RoomNumber} - Khach: {guestName}");
                Console.WriteLine($"Check-in: {checkInTime}");
                Console.WriteLine($"Check-out: {checkOutTime}");
                Console.WriteLine("----------------------");
            }
            //Console.WriteLine("\nDanh sach phong dat truoc:");
            //foreach (var room in rooms)
            //{
            //    Console.WriteLine($"Phong {room.RoomNumber} - Khach: {(room.Guests != null ? room.Occupant.Name : "Chua co khach")}");
            //    Console.WriteLine($"Check-in: {room.Occupant.CheckInTime}");
            //    Console.WriteLine($"Check-out: {room.Occupant.CheckOutTime}");
            //    Console.WriteLine("----------------------");
            //}         

        }
        public void StatusRoom()
        {
            Console.WriteLine("\nCap nhat trang thai phong");
            foreach (var room in rooms)
            {
                string status = room.IsOccupied ? "Co khach" : "Trong";
                Console.WriteLine($"Phong {room.RoomNumber}: {status}");
            }
        }

    }
}
