using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class OccurencesInStringCounter
    {
        protected IHashableStringWithArray _hashableStringWithArray;

        public OccurencesInStringCounter (IHashableStringWithArray hashableStringWithArray)
        {
            this._hashableStringWithArray = hashableStringWithArray;
        }
        
        public int numberOfOccurences(AbstractHashableString hashableStringToCheck)
        {
            int lastIndexOfCheck = this._hashableStringWithArray.Length() - hashableStringToCheck.Length() + 1;
            
            int res = 0;
            for (int i = 0; i < lastIndexOfCheck; ++i)
            {
                if (this._hashableStringWithArray
                        .HashOfSubstring(i, hashableStringToCheck.Length()) == hashableStringToCheck.Hash)
                    ++res;
            }

            return res;
        }
    }
}
