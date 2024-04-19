
using HotelTask.Exceptions;
using HotelTask.Models;
using System.Security.Cryptography.X509Certificates;

namespace HotelTask
{
    internal class Program//:IHotelMenu
    {
        static void Main(string[] args)
		{
            try
            {
                Console.WriteLine("***************Menu***************");
                bool mainexit = false;
                HotelAdmin admin = new HotelAdmin();
            MainMenu:
                do
                {
                    Console.WriteLine("1.Sisteme giris\r\n0.Cixis");
                    string mainchoice = Console.ReadLine();
                    switch (mainchoice)
                    {
                        case "1":
                        Hotelmenu:
                            
                            Console.WriteLine("1.Hotel yarat\r\n2.Butun Hotelleri gor\r\n3.Hotel sec \r\n0.Exit");
                            string hotelchoice = Console.ReadLine();
                            switch (hotelchoice)
                            {
                                case "1":
                                    Console.WriteLine("Hotel adini daxil edin");
                                    string hotelname = Console.ReadLine();
                                    Hotel userhotel = new Hotel(hotelname);
                                    admin.AddHotel(userhotel);
                                    goto Hotelmenu;
                                case "2":
                                    Console.WriteLine("Sizin hoteller:\r\n");
                                    foreach (Hotel item in admin.GetAllHotels())
                                    {
                                        Console.WriteLine(item.ToString());
                                        Console.WriteLine("\r\n");
                                    }
                                    goto Hotelmenu;
                                case "3":
                                    Console.WriteLine("secdiyiniz otelin adini daxil edin");
                                    string selectedname= Console.ReadLine();
                                    Hotel selectedhotel = admin.GetHotel(selectedname);
                                    Roomname:
                                    Console.WriteLine($"*****{selectedhotel.Name}******");
                                    Console.WriteLine("1.Room yarat\r\n2.Roomlari gor\r\n3.Rezervasya et\r\n4.Evvelki menuya qayit.\r\n0.Exit");
                                    string roomchoice= Console.ReadLine();
                                    switch (roomchoice)
                                    {
                                        case "1":
                                            Console.WriteLine("Otaqin adini daxil edin");
                                            string roomname= Console.ReadLine();
                                            Console.WriteLine("Otaqin qiymetini daxil edin");
                                            int roomprice = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Otaqin capaitisini daxil edin");
                                            byte roomcapacity = Convert.ToByte(Console.ReadLine());
                                            Room useroom = new Room(roomname,roomprice,roomcapacity);
                                            selectedhotel.AddRoom(useroom);
                                            Console.WriteLine("\r\n");
                                            goto Roomname;
                                        case "2":
                                            Predicate<string> method = (name) => name != null;
                                            if (selectedhotel.GetRoomsList(method) == null)
                                            {
                                                throw new NotAviableException("Otaq tapilmadi");
                                            }
                                            foreach (Room item in selectedhotel.GetRoomsList(method))
                                            {
                                                Console.WriteLine(item.ToString());
                                            }
                                            goto Roomname;
                                        case "3":
                                            Predicate<string> method1 = (name) => name != null;
                                            List<Room> rooms = selectedhotel.GetRoomsList(method1);
                                            if (selectedhotel.GetRoomsList(method1)==null)
                                            {
                                                throw new NotAviableException("Rezervasiya xidmeti iwlemir");
                                            }
                                            Console.WriteLine("Room-un adini daxil edin");
                                            string roomname1= Console.ReadLine();
                                            Room selroom = rooms.Find(x=>x.Name==roomname1);
                                            selectedhotel.MakeReservation(selroom.ID, selroom.PersonCapacity);
                                            goto Roomname;
                                        case "4":
                                            goto Hotelmenu;
                                        case "0":
                                            Console.WriteLine("Good bye");
                                            mainexit =true;
                                            break;
                                        default:
                                            Console.WriteLine("Duzgun emeliyat secin");
                                            goto Roomname;
                                    }
                                    break;
                                case "4":
                                    Console.WriteLine("\nGood bye");
                                    mainexit = true;
                                    break;
                                default:
                                    Console.WriteLine("\nDuzgun emeliyat secin");
                                    goto Hotelmenu;
                            }

                            break;
                        case "0":
                            Console.WriteLine("\nGood Bye");
                            mainexit = true;
                            break;
                        default:
                            Console.WriteLine("\nDuzgun emeliyat secin");
                            break;
                    }

                } while (mainexit != true);
            }
            catch (CapacityException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch(NotAviableException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
