using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir
{
    public static class EnumExtentions
    {
        public static IDictionary<int, string> GetEnumAsDictionary<T>()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Type T must be an Enum");

            IEnumerable<int> temp = Enum.GetValues(typeof(T)).Cast<int>();
            return temp.ToDictionary(v => v, k => Enum.GetName(typeof(T) , k));
        }
    }
}
