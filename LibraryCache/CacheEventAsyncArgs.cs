using System;

namespace Library.Cache
{
    internal delegate void AsyncLibraryEventHandler(CacheEventAsyncArgs arg);

    internal class CacheEventAsyncArgs : EventArgs
    {
        #region Fields + Properties

        public string File { get; }
        public Guid Guid { get; }

        #endregion Fields + Properties

        #region Constructors

        // Is in fact called through async call when fired
        public CacheEventAsyncArgs(string file)
        {
            File = file;
        }

        // Is in fact called through async call when fired
        public CacheEventAsyncArgs(string file, Guid guid)
        {
            File = file;
            Guid = guid;
        }

        #endregion Constructors
    }
}
