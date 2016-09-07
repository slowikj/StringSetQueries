using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class HashableStringPModuloWithArray : HashableStringPModulo, IHashableStringWithArray
    {
        protected long[] _suffixHashes;
        protected PowersComputerModulo _powerComputer;

        public HashableStringPModuloWithArray (string s, int p, int modulo) : base(s, p, modulo)
        {
            this._powerComputer = new PowersComputerModulo(p, s.Length, modulo);
        }
        
        public long HashOfSubstring (int start, int len)
        {
            return ((this.HashOfSuffix(start)
                       - (this.HashOfSuffix(start + len) * this._powerComputer.GetPower(len))) % this._modulo
                       + this._modulo) % this._modulo;
        }
        
        protected long HashOfSuffix (int start)
        {
            if (this._suffixHashes == null)
                this._suffixHashes = this.GetSuffixHashes();
             
            return this._suffixHashes[start];
        }

        protected virtual long[] GetSuffixHashes ()
        {
            int sLen = this._s.Length;
            long[] res = new long[sLen + 1];
            res[sLen - 1] = this._s[sLen - 1];

            for (int i = sLen - 2; i >= 0; --i)
                res[i] = ((res[i + 1] * this._p) + this._s[i]) % this._modulo;

            return res;
        }
    }
}
