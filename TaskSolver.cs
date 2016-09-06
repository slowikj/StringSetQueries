using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class TaskSolver
    {
        private Dictionary<string, AbstractHashableString> _givenStrings;
        private IHashableStringFactory _hashableStringFactory;

        public TaskSolver (IHashableStringFactory hashableStringFactory)
        {
            this._hashableStringFactory = hashableStringFactory;
            this._givenStrings = new Dictionary<string, AbstractHashableString>();
        }

        public void AddString (string s)
        {
            this._givenStrings.Add(s, this._hashableStringFactory
                                          .GetHashableStringWithoutArray(s));
        }

        public void DeleteString (string s)
        {
            this._givenStrings.Remove(s);
        }

        public long NumberOfOccurencesOfStringsFromSetIn (string text)
        {
            OccurencesInStringCounter counter = new OccurencesInStringCounter(this._hashableStringFactory
                                                                                   .GetHashableStringWithArray(text));

            int res = 0;
            foreach (var s in this._givenStrings)
                res += counter.numberOfOccurences(s.Value);

            return res;
        }
    }
}
