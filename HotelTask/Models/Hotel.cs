using HotelTask.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Models
{
    internal class Hotel
    {
        static int _id;
        public int ID { get; set; }
        public string Name { get; set; }
        List<Room> roomslist=new List<Room>();
        public Hotel(string name)
        {
            ID = ++_id;
            Name = name;
        }
        public void AddRoom(Room room)
        {
            roomslist.Add(room);
            Console.WriteLine("Room elave edildi");
        }
        public List<Room> GetRoomsList(Predicate<string> method)
        {
            List<Room> voidlist = new List<Room>();
            if (!method(Name))
            {
                return voidlist;
            }
            return roomslist;

        }
         public void MakeReservation(int? id,byte capacity)
        {
            if (id==null)
            {
                throw new NullReferenceException();
            }
            else if (id!=null)
            {
                foreach (Room room in roomslist)
                {
                    if (room.ID==id)
                    {
                        if (!room.isAviable)
                        {
                            throw new NotAviableException("bu otaq artiq rezerv olunub");

                        }
                        else if (room.isAviable)
                        {
                            if (room.PersonCapacity < capacity)
                            {
                                throw new CapacityException("Daxil etdiyiniz capacity roomun capacitisinen coxdu");
                            }
                            else if (room.PersonCapacity>=capacity)
                            {
                                Console.WriteLine("Reserv olundu");
                                room.isAviable= false;

                            }
                        }

                    }
                    else { continue; }
                }

            }
        }

        public string Showinfo()
        {
            return $"{ID}- hotel id||{Name}-hotel name";
        }
        public override string ToString()
        {
            return Showinfo();
        }
    }
}
