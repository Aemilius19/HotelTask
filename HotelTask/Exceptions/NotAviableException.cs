using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Exceptions
{
    internal class NotAviableException:Exception
    {
        public NotAviableException()
        {
            
        }
        public NotAviableException(string message):base(message)
        {
            
        }
    }
}
