using Library.Resources;
using System;

namespace Library.Cache.Objects
{
    [Serializable]
    public struct Index
    {
        #region Fields + Properties

        public string File { get; set; }
        public CacheObjects ObjectType { get; set; }

        #endregion Fields + Properties

        #region Methods

        public static bool operator !=(Index item1, Index item2)
        {
            return !item1.Equals(item2);
        }

        public static bool operator ==(Index item1, Index item2)
        {
            return item1.Equals(item2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Index))
                return false;

            return Equals((Index)obj);
        }

        public bool Equals(Index other)
        {
            if (File != other.File || ObjectType != other.ObjectType)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return File.GetHashCode() ^ ObjectType.GetHashCode();
        }

        #endregion Methods
    }
}
