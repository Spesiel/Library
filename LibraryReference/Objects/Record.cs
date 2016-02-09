using System;

namespace Library.Resources.Objects
{
    [Serializable]
    public struct Record : IArtifact
    {
        #region Fields + Properties

        public string File { get; set; }
        public Kind Kind { get; set; }

        #endregion Fields + Properties

        #region Methods

        public static bool operator !=(Record item1, Record item2)
        {
            return !item1.Equals(item2);
        }

        public static bool operator ==(Record item1, Record item2)
        {
            return item1.Equals(item2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Record))
                return false;

            return Equals((Record)obj);
        }

        public bool Equals(Record other)
        {
            if (File != other.File || Kind != other.Kind)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return File.GetHashCode() ^ Kind.GetHashCode();
        }

        #endregion Methods
    }
}
