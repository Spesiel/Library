namespace Library.Cache
{
    public static class Libraries
    {
        public static void Initialization()
        {
            Index.Register();
        }

        #region Flush / Clear

        public static void Clear()
        {
            Index.Clear();

            Thumbnails.Clear();
        }

        public static void Flush()
        {
            Index.Flush();

            Thumbnails.Flush();
        }

        #endregion Flush / Clear
    }
}