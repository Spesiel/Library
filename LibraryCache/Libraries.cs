namespace Library.Cache
{
    public static class Libraries
    {
        private static Index _Index = new Index();
        private static Thumbnails _Thumbnails = new Thumbnails();
        public static Index Index { get { return _Index; } }
        public static Thumbnails Thumbnails { get { return _Thumbnails; } }

        public static void Initialization()
        {
            _Index.Register();
        }

        #region Flush / Clear

        public static void Clear()
        {
            _Index.Clear();

            _Thumbnails.Clear();
        }

        public static void Flush()
        {
            _Index.Flush();

            _Thumbnails.Flush();
        }

        #endregion Flush / Clear
    }
}