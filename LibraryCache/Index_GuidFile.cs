using Library.Cache.Objects;
using Library.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Cache
{
    internal class Index_GuidFile : Cache<Guid, Index>
    {
        #region Methods

        public void Add(Guid guid, string file, CacheObjects type)
        {
            Index index = new Index { File = file, ObjectType = type };
            Library.Add(guid, index);
        }

        public IEnumerable<Tuple<Guid, CacheObjects>> GetGuids(string file)
        {
            return Library.Where(l => l.Value.File.Equals(file)).Select(o => Tuple.Create(o.Key, o.Value.ObjectType));
        }

        #endregion Methods

        #region Constructors

        public Index_GuidFile() : base(nameof(Index_GuidFile))
        {
        }

        #endregion Constructors
    }
}
