using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class TaskSolver
    {
        private HashSet<AbstractHashableString> _searchKeys;
        private IHashableStringFactory _hashableStringFactory;

        public TaskSolver (IHashableStringFactory hashableStringFactory)
        {
            this._hashableStringFactory = hashableStringFactory;
            this._searchKeys = new HashSet<AbstractHashableString>();
        }

        public void AddSearchKey (string s)
        {
            this._searchKeys.Add(this._hashableStringFactory
                                     .GetHashableStringWithoutArray(s));
        }

        public void RemoveSearchKey (string s)
        {
            this._searchKeys.Remove(this._hashableStringFactory
                                        .GetHashableStringWithoutArray(s));
        }

        public long NumberOfOccurencesOfKeys (string text)
        {
            OccurencesInStringCounter counter = new OccurencesInStringCounter(this._hashableStringFactory
                                                                                  .GetHashableStringWithArray(text));

            return Enumerable.Sum<AbstractHashableString> (this._searchKeys,
                                                           (AbstractHashableString str) =>
                                                                counter.NumberOfOccurences(str)
                                                          );
        }
    }
}
