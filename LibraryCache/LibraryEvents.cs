namespace Library.Cache
{
    internal delegate void LibraryEventHandler(LibraryEventArgs arg);

    internal class LibraryEventArgs
    {
        public string File { get; internal set; }

        public bool IsNew { get; internal set; }

        public LibraryEventArgs(string file, bool isNew)
        {
            File = file;
            IsNew = isNew;
        }
    }
}