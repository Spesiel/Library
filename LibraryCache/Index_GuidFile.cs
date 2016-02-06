using System;

namespace Library.Cache
{
    internal class Index_GuidFile : Cache<Guid, string>
    {
        #region Constructors

        public Index_GuidFile() : base(nameof(Index_GuidFile))
        {
        }

        #endregion Constructors
    }
}
