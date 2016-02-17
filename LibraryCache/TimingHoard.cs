using Library.Resources.Objects;
using System;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the items.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    public sealed class TimingHoard : HoardBase<Guid, Timing>
    {
        #region Delegates + Events

        internal static event AsyncCacheEventHandler TimingAdded;

        #endregion Delegates + Events

        #region Methods

        public void Add(string file, Timing timing)
        {
            Guid guid = Guid.NewGuid();
            Add(guid, timing);
            TimingAdded(new CacheEventAsyncArgs(file, guid));
        }

        public void Set(string file, Timing oldTiming, Timing newTiming)
        {
            Library[Library.First(i => i.Value.Equals(oldTiming)).Key] = newTiming;
        }

        #endregion Methods

        #region Constructors

        public TimingHoard() : base(nameof(TimingHoard))
        {
        }

        #endregion Constructors
    }
}
