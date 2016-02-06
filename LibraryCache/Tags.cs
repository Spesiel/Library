using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the items.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    public class Tags : Cache<Guid, string>
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

        public IEnumerable<string> Get(string file)
        {
            return Library.Where(l => Access.Index_GuidFile.Get(file).Any().Equals(l.Key)).Select(i => i.Value);
        }

        #endregion Methods

        #region Constructors

        public Tags() : base(nameof(Tags))
        {
        }

        #endregion Constructors
    }
}
