using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class PowersComputerModulo
    {
        private long[] _power;
        protected int _p, _maxExponent, _modulo;

        public PowersComputerModulo(int p, int maxExponent, int modulo)
        {
            this._p = p;
            this._maxExponent = maxExponent;
            this._modulo = modulo;
        }

        public long GetPower(int exp)
        {
            if (this._power == null)
                this._power = this.GetComputedPowers();

            return this._power[exp];
        }

        protected long[] GetComputedPowers()
        {
            long[] res = new long[this._maxExponent + 1];
            res[0] = 1;

            for (int i = 1; i <= this._maxExponent; ++i)
                res[i] = (res[i - 1] * this._p) % this._modulo;

            return res;
        }
    }
}
