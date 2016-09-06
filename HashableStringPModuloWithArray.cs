using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class HashableStringPModuloWithArray : HashableStringPModulo, IHashableStringWithArray
    {
        private long[] _hashSuffixArray; 
        
        public HashableStringPModuloWithArray (string s, int p, int mod) : base (s, p, mod)
        {
        }
        
        protected long HashOfSuffix (int start)
        {
            if (this._hashSuffixArray == null)
                this.ComputeHash();

            return this._hashSuffixArray[start];
        }

        protected long PowerP (long k)
        {
            long res = 1;
            long a = this._p;

            while (k > 0)
            {
                if (k % 2 == 1)
                    res = (res * a) % this._modulo;

                a = (a * a) % this._modulo;

                k /= 2;
            }

            return res;
        }

        public long HashOfSubstring(int start, int len)
        {
            long tmp = ((this.HashOfSuffix(start) - (this.HashOfSuffix(start + len) * PowerP(len))) % this._modulo
                     + this._modulo) % this._modulo;
            
            return tmp;
        }
        
        protected override void ComputeHash()
        {
            int sLen = this.Length();
            this._hashSuffixArray = new long[sLen + 1];
            this._hashSuffixArray[sLen - 1] = this._s[sLen - 1];

            for (int i = sLen - 2; i >= 0; --i)
                this._hashSuffixArray[i] = ((this._hashSuffixArray[i + 1] * this._p) + this._s[i]) % this._modulo;

            this.Hash = this._hashSuffixArray[0];
        }
    }
}
