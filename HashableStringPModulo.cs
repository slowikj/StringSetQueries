using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class HashableStringPModulo : AbstractHashableString
    {
        protected int _p, _modulo;

        public HashableStringPModulo(string s, int p, int mod) : base(s)
        {
            this._p = p;
            this._modulo = mod;
        }

        protected override long GetHashFrom (string s)
        {
            long res = 0;
            for (int i = this.Length() - 1; i >= 0; --i)
                res = ((res * this._p) + s[i]) % this._modulo;

            return res;
        }
    }
}
