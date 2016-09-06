using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class HashableStringPModuloFactory : IHashableStringFactory
    {
        private const int default_p = 101, default_modulo = 1000000007;
        private int _p, _modulo;

        public HashableStringPModuloFactory (int p = default_p, int modulo = default_modulo)
        {
            this._p = p;
            this._modulo = modulo;
        }

        public IHashableStringWithArray GetHashableStringWithArray(string s)
        {
            return new HashableStringPModuloWithArray(s, this._p, this._modulo);
        }

        public AbstractHashableString GetHashableStringWithoutArray(string s)
        {
            return new HashableStringPModulo(s, this._p, this._modulo);
        }
    }
}
