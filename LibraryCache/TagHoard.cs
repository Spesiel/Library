using System;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the items.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    public sealed class TagHoard : HoardBase<Guid, string>
    {
        #region Delegates + Events

        internal static event AsyncCacheEventHandler TagAdded;

        #endregion Delegates + Events

        #region Methods

        public void Add(string file, string tag)
        {
            Guid guid = Guid.NewGuid();
            Add(guid, tag);
            TagAdded(new CacheEventAsyncArgs(file, guid));
        }

        public void Set(string file, string oldTag, string newTag)
        {
            Library[Library.First(i => i.Value.Equals(oldTag)).Key] = newTag;
        }

        #endregion Methods

        #region Constructors

        public TagHoard() : base(nameof(TagHoard))
        {
        }

        #endregion Constructors
    }
}
