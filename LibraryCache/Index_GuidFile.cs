using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Cache
{
    internal class Index_GuidFile : Cache<Guid, string>
    {
        #region Methods

        public IEnumerable<Guid> GetGuids(string file)
        {
            return Library.Where(l => l.Value.Equals(file)).Select(o => o.Key);
        }

        #endregion Methods

        #region Constructors

        public Index_GuidFile() : base(nameof(Index_GuidFile))
        {
        }

        #endregion Constructors
    }
}
