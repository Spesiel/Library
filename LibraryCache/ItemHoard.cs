using Library.Resources.Objects;
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

        public override bool Remove(string key)
        {
            bool ans = base.Remove(key);
            ItemRemoved(new CacheEventAsyncArgs(key));

            return ans;
        }

        internal IEnumerable<string> Search(string location) => Library.Keys.Where(i => i.StartsWith(location)).OrderBy(o => o);

        #endregion Methods

        #region Constructors

        public ItemHoard() : base(nameof(ItemHoard))
        {
        }

        #endregion Constructors
    }
}
