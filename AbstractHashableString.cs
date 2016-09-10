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
        
        public long Hash
        {
            get
            {
                if (this._hash == NOT_COUNTED)
                    this._hash = this.GetHashFrom(this._s);

                return this._hash;
            }

            protected set
            {
                this._hash = value;
            }
        }

        public AbstractHashableString(string s)
        {
            this._s = s;
        }

        protected abstract long GetHashFrom (string s);
        
        public int Length ()
        {
            return this._s.Length;
        }

        public override int GetHashCode()
        {
            const int ModuloToTruncate = 1000000033;
            return (int)(this.Hash % ModuloToTruncate);
        }

        public override bool Equals(object obj)
        {
            return (obj is AbstractHashableString) ? this._s == (obj as AbstractHashableString)._s
                                                   : false;
        }

        public override string ToString()
        {
            return this._s;
        }
    }
}
