using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    interface IHashableStringWithArray
    {
        long HashOfSubstring(int start, int len);

        int Length();
    }
}
