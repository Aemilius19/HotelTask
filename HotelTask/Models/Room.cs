using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Models
{
    internal class Room
    {
        static int _id;
        public int ID { get;}

        public string Name { get; set; }
        public int Price { get; set; }

        public byte PersonCapacity { get; set; }

        public bool isAviable = true;
        public Room(string name,int price, byte personcapacity)
        {
            ID = ++_id;
            Name = name;
            Price = price;
            PersonCapacity = personcapacity;           
        }

        public string Showinfo()
        {
            return $"{ID}- room id, {Name}-room name,  {Price}- room price, {PersonCapacity}- room capacity";
        }
        public override string ToString()
        {
            return Showinfo();
        }
    }
}
