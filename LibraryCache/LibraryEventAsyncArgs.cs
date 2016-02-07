using System;

namespace Library.Cache
{
    internal delegate void AsyncLibraryEventHandler(LibraryEventAsyncArgs arg);

    internal class LibraryEventAsyncArgs : EventArgs
    {
        #region Fields + Properties

        public string File { get; }
        public Guid Guid { get; }

        #endregion Fields + Properties

        #region Constructors

        // Is in fact called through async call when fired
        public LibraryEventAsyncArgs(string file)
        {
            File = file;
        }

        // Is in fact called through async call when fired
        public LibraryEventAsyncArgs(string file, Guid guid)
        {
            File = file;
            Guid = guid;
        }

        #endregion Constructors
    }
}
