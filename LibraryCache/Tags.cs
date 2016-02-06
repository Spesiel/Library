using System;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the items.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    public sealed class Tags : Cache<Guid, string>
    {
        #region Delegates + Events

        internal static event AsyncLibraryEventHandler TagAdded;

        #endregion Delegates + Events

        #region Methods

        public void Add(string file, string tag)
        {
            Guid guid = Guid.NewGuid();
            base.Add(guid, tag);
            TagAdded(new LibraryEventAsyncArgs(file, guid));
        }

        #endregion Methods

        #region Constructors

        public Tags() : base(nameof(Tags))
        {
        }

        #endregion Constructors
    }
}
