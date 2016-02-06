using System;

namespace Library.Cache
{
    internal delegate void AsyncLibraryEventHandler(LibraryEventAsyncArgs arg);

    internal class LibraryEventAsyncArgs : EventArgs
    {
        #region Fields + Properties

        public string File { get; }

        public bool IsNew { get; }

        #endregion Fields + Properties

        #region Constructors

        // Is in fact called through async call when fired
        public LibraryEventAsyncArgs(string file)
        {
            File = file;
        }

        // Is in fact called through async call when fired
        public LibraryEventAsyncArgs(string file, bool isNew)
        {
            File = file;
            IsNew = isNew;
        }

        #endregion Constructors
    }
}
