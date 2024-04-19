using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Exceptions
{
    internal class CapacityException:Exception
    {
        public CapacityException()
        {
            
        }
        public CapacityException(string message):base(message) 
        {
            
        }
    }
}
