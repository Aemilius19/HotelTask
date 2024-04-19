using HotelTask.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Models
{
    internal class HotelAdmin
    {
        List<Hotel> hotellist=new List<Hotel>();

        public  void AddHotel(Hotel hotelss)
        {
            if (hotellist.Contains(hotelss) == false)
            {
                hotellist.Add(hotelss);
                Console.WriteLine($"hotel elave olundu\r\n{hotelss.ToString()}");
                Console.WriteLine("------------------------");
            }
            else if (hotellist.Contains(hotelss) == true)
            {
                throw new NotAviableException("Bu adli otel artiq yaradilib");
            }
            
        }

        public List<Hotel> GetAllHotels()
        {
            List<Hotel> gettedhotels= new List<Hotel>();
            if (hotellist.Count != 0)
            {
                for (int i = 0; i < hotellist.Count; i++)
                {
                    gettedhotels.Add(hotellist[i]);
                }  
            }

            else { throw new NotAviableException("hoteller tapilmadi"); }
            return gettedhotels;
        }

        public Hotel GetHotel(string name)
        {
           Hotel gethotel= hotellist.Find(x => x.Name.ToLower() == name.ToLower());
            return gethotel;
        }
    }
}
