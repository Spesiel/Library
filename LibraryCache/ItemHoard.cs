using Library.Cache.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the items.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    public sealed class ItemHoard : HoardBase<string, Item>
    {
        #region Delegates + Events

        internal static event AsyncCacheEventHandler ItemRemoved;

        #endregion Delegates + Events

        #region Methods

        internal override void Remove(string file)
        {
            base.Remove(file);
            ItemRemoved(new CacheEventAsyncArgs(file));
        }

        internal IEnumerable<string> Search(string location)
        {
            return Library.Keys.Where(i => i.StartsWith(location)).OrderBy(o => o);
        }

        #endregion Methods

        #region Constructors

        public ItemHoard() : base(nameof(ItemHoard))
        {
        }

        #endregion Constructors
    }
}
