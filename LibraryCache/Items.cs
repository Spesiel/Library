using Library.Cache.Objects;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the items.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    public sealed class Items : Cache<string, Item>
    {
        #region Delegates + Events

        internal static event AsyncLibraryEventHandler ItemRemoved;

        #endregion Delegates + Events

        #region Methods

        internal override void Remove(string file)
        {
            base.Remove(file);
            ItemRemoved(new LibraryEventAsyncArgs(file));
        }

        #endregion Methods

        #region Constructors

        public Items() : base(nameof(Items))
        {
        }

        #endregion Constructors
    }
}
