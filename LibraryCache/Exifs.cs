using Library.Cache.Objects;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the thumbnails.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    internal class Exifs : Cache<string, Exif>
    {
        #region Constructors

        public Exifs() : base(nameof(Exifs))
        {
        }

        #endregion Constructors
    }
}
