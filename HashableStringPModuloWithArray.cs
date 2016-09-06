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
        private long[] _powerOfP;

        public HashableStringPModuloWithArray (string s, int p, int mod) : base (s, p, mod)
        {
        }
        
        public long HashOfSubstring(int start, int len)
        {
            long tmp = ((this.HashOfSuffix(start) - (this.HashOfSuffix(start + len) * this.GetPowerOfP(len))) % this._modulo
                     + this._modulo) % this._modulo;
            
            return tmp;
        }
        
        protected long HashOfSuffix(int start)
        {
            if (this._hashSuffixArray == null)
                this.ComputeHash();

            return this._hashSuffixArray[start];
        }

        protected long GetPowerOfP (int exp)
        {
            if (this._powerOfP == null)
                this.ComputePowersOfP();

            return this._powerOfP[exp];
        }

        protected void ComputePowersOfP()
        {
            this._powerOfP = new long[this._s.Length + 1];
            this._powerOfP[0] = 1;

            for (int i = 1; i < this._powerOfP.Length; ++i)
                this._powerOfP[i] = (this._powerOfP[i - 1] * this._p) % this._modulo;
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
