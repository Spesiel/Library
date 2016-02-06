using System;

namespace Library.Cache
{
    internal class Index_FileGuid : Cache<string, Guid>
    {
        #region Constructors

        public Index_FileGuid() : base(nameof(Index_FileGuid))
        {
        }

        #endregion Constructors
    }
}
