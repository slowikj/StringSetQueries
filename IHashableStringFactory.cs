using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    interface IHashableStringFactory
    {
        AbstractHashableString GetHashableStringWithoutArray(string s);
        IHashableStringWithArray GetHashableStringWithArray(string s);
    }
}
