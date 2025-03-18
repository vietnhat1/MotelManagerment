using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelManagerment
{
    internal class Program
    {


        static void Main(string[] args)
        {



            while (true)
            {
                Console.WriteLine("|==================| QUAN LY PHONG TRO |==================|");
                Console.WriteLine("|          1. Quan ly phong                               |");
                Console.WriteLine("|          2. Quan ly khach thue                          |");
                Console.WriteLine("|          3. He thong thanh toan                         |");
                Console.WriteLine("|          4. He thong ghi log                            |");
                Console.WriteLine("|          5. Tinh toan nang cao                          |");
                Console.WriteLine("|          0. Thoat                                       |");
                Console.WriteLine("|=========================================================|");
                Console.Write("Vui long chon chuc nang: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": RoomManagement(); break;
                    case "2": GuestManagement(); break;
                    case "3": BillingSystem(); break;
                    case "4": LoggingSystem(); break;
                    case "5": AdvancedFeatures(); break;
                    case "0": return;
                    default: Console.WriteLine("Lua chon khong hop le!"); break;
                }
            }
        }

        static void RoomManagement()
        {
            MotelManager motel = new MotelManager();
            Console.WriteLine("|==================| QUAN LY PHONG |==================|");
            Console.WriteLine("|          1. Hien thi tat ca phong                   |");
            Console.WriteLine("|          2. Hien thi phong trong                    |");
            Console.WriteLine("|          3. Hien thi phong da thue                  |");
            Console.WriteLine("|          4. Xem thong tin phong                     |");
            Console.WriteLine("|          0. Quay lai                                |");
            Console.WriteLine("|=====================================================|");
            Console.Write("Vui long chon chuc nang: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": motel.DisplayRoomList(); break;
                case "2": motel.DisplayEmptyRooms(); break;
                case "3": motel.DisplayOccupiedRooms(); break;
                case "4": motel.CheckRoomInfo(); break;
                case "0": return;
                default: Console.WriteLine("Lua chon khong hop le!"); break;
            }
        }

        static void GuestManagement()
        {
            MotelManager motel = new MotelManager();
            Console.WriteLine("|==================| QUAN LY KHACH THUE |==================|");
            Console.WriteLine("|          1. Hien thi tat ca khach thue                   |");
            Console.WriteLine("|          2. Thoi gian nhan - tra phong                   |");
            Console.WriteLine("|          3. Thoi gian luu tru                            |");
            Console.WriteLine("|          0. Quay lai                                     |");
            Console.WriteLine("|==========================================================|");
            Console.Write("Vui long chon chuc nang: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": motel.DisplayGuestList(); break;
                case "2": motel.DisplayGuestStayDuration(); break;
                case "3": motel.LogGuestCheckOut(); break;
                case "0": return;
                default: Console.WriteLine("Lua chon khong hop le!"); break;
            }
        }

        static void BillingSystem()
        {
            MotelManager motel = new MotelManager();
            Console.WriteLine("|==================| HE THONG THANH TOAN |==================|");
            Console.WriteLine("|          1. Chinh sua gia thue                            |");
            Console.WriteLine("|          2. Xuat hoa don                                  |");
            Console.WriteLine("|          0. Quay lai                                      |");
            Console.WriteLine("|===========================================================|");
            Console.Write("Vui long chon chuc nang: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": motel.ModifyPriceRoom(); break;
                case "2": motel.Bill(); break;
                default: Console.WriteLine("Lua chon khong hop le!"); break;
            }
        }

        static void LoggingSystem()
        {
            MotelManager motel = new MotelManager();
            Console.WriteLine("|==================| HE THONG GHI LOG |==================|");
            Console.WriteLine("|          1. Luu check in / check out                   |");
            Console.WriteLine("|          2. Luu lich su thanh toan                     |");
            Console.WriteLine("|          3. Theo doi thay doi trang thai phong         |");
            Console.WriteLine("|          0. Quay lai                                   |");
            Console.WriteLine("|========================================================|");
            Console.Write("Vui long chon chuc nang: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": motel.Bill(); break;
                case "2": motel.Bill(); break;
                default: Console.WriteLine("Lua chon khong hop le!"); break;
            }
        }

        static void AdvancedFeatures()
        {
            MotelManager motel = new MotelManager();
            Console.WriteLine("|==================| TINH NANG NANG CAO |==================|");
            Console.WriteLine("|          1. He thong dat phong                           |");
            Console.WriteLine("|          2. Theo doi don dep                             |");
            Console.WriteLine("|          3. Xac thuc quan tri vien                       |");
            Console.WriteLine("|          4. Tim kiem khach                               |");
            Console.WriteLine("|          0. Quay lai                                     |");
            Console.WriteLine("|==========================================================|");
            Console.Write("Vui long chon chuc nang: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": BookingRoom(); break;
                case "2":; break;
                default: Console.WriteLine("Lua chon khong hop le!"); break;
            }
        }
        static void BookingRoom()
        {
            MotelManager motel = new MotelManager();
            Console.WriteLine("|==================| HE THONG DAT PHONG |==================|");
            Console.WriteLine("|          1. Dat phong moi                                |");
            Console.WriteLine("|          2. Hien thi danh sach dat phong                 |");
            Console.WriteLine("|          3. Cap nhat trang thai phong                    |");
            Console.WriteLine("|          0. Quay lai                                     |");
            Console.WriteLine("|==========================================================|");
            Console.Write("Vui long chon chuc nang: ");
            string choice = Console.ReadLine() ;
            switch (choice)
            {
                case "1": motel.NewReservation(); break;
                case "2": motel.ViewReservation(); break;
                case "3": motel.StatusRoom(); break;
                default: Console.WriteLine("Lua chon khong hop le!"); break;
            }
        }
    }
}
