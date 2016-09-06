using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    abstract class AbstractHashableString
    {
        private const long NOT_COUNTED = -1;
        protected string _s;
        private long _hash = NOT_COUNTED;

        protected virtual void ComputeHash ()
        {
            this.Hash = this.GetHashFrom(this._s);
        }

        public long Hash
        {
            get
            {
                if (this._hash == NOT_COUNTED)
                    this.ComputeHash();

                return this._hash;
            }

            protected set
            {
                this._hash = value;
            }
        }

        protected abstract long GetHashFrom (string s);

        public AbstractHashableString (string s)
        {
            this._s = s;
        }
        
        public int Length ()
        {
            return this._s.Length;
        }
    }
}
