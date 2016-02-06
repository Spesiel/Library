using Library.Cache.Objects;
using Library.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Cache
{
    internal sealed class Catalog : Cache<Guid, Record>
    {
        #region Methods

        public void Add(Guid id, string file, Kind kind)
        {
            Library.Add(id, new Record { File = file, Kind = kind });
        }

        public Dictionary<Guid, Kind> GetGuids(string file)
        {
            return Library.Where(l => l.Value.File.Equals(file)).ToDictionary(o => o.Key, o => o.Value.Kind);
        }

        #endregion Methods

        #region Constructors

        public Catalog() : base(nameof(Catalog))
        {
        }

        #endregion Constructors
    }
}
