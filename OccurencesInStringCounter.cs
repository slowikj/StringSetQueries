using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class OccurencesInStringCounter
    {
        protected IHashableStringWithArray _text;

        public OccurencesInStringCounter (IHashableStringWithArray text)
        {
            this._text = text;
        }
        
        public int numberOfOccurences(AbstractHashableString stringToCheck)
        {
            int lastIndexOfCheck = this._text.Length() - stringToCheck.Length();
            
            int res = 0;
            for (int i = 0; i <= lastIndexOfCheck; ++i)
            {
                if (this._text
                        .HashOfSubstring(i, stringToCheck.Length()) == stringToCheck.Hash)
                    ++res;
            }

            return res;
        }
    }
}
