using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFunctions.Models
{
    public static class GlobalFunctions
    {
        public static bool IsNotEmpty(params string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
                if (strings[i].Length == 0)
                    return false;
            return true;
        }
    }
}
