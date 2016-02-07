using Library.Cache.Objects;
using System;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the items.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    public sealed class PersonHoard : HoardBase<Guid, Person>
    {
        #region Delegates + Events

        internal static event AsyncLibraryEventHandler PersonAdded;

        #endregion Delegates + Events

        #region Methods

        public void Add(string file, Person person)
        {
            Guid guid = Guid.NewGuid();
            Add(guid, person);
            PersonAdded(new LibraryEventAsyncArgs(file, guid));
        }

        #endregion Methods

        #region Constructors

        public PersonHoard() : base(nameof(PersonHoard))
        {
        }

        #endregion Constructors
    }
}
