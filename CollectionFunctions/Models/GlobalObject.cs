using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFunctions.Models
{
    public static class GlobalObject
    {
        public static List<User> userList = new List<User>();
    }

    public static class Counter
    {
        public static int value = 0;
        public static void IncreaseValue()
        {
            value++;
            if (value >= 3)
                value = 0;
        }
    }
}
