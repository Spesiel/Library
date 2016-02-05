using System;

namespace Library.Cache
{
    internal delegate void LibraryEventHandler(LibraryEventArgs arg);

    internal class LibraryEventArgs : EventArgs
    {
        public string File { get; }

        public bool IsNew { get; }

        public LibraryEventArgs(string file)
        {
            File = file;
        }

        public LibraryEventArgs(string file, bool isNew)
        {
            File = file;
            IsNew = isNew;
        }
    }
}