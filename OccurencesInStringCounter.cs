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

        public int NumberOfOccurences (AbstractHashableString stringToCheck)
        {
            int lastIndexOfCheck = this._text.Length() - stringToCheck.Length();
            
            return Enumerable.Count<int>(Enumerable.Range(0, lastIndexOfCheck + 1),
                                         (int start) => this._text.HashOfSubstring(start, stringToCheck.Length())
                                                        == stringToCheck.Hash
                                        );
        }
    }
}
