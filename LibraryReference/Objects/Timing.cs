using System;

namespace Library.Resources.Objects
{
    [Serializable]
    public struct Timing : IArtifact
    {
        #region Fields + Properties

        public DateTime Date { get; set; }
        public TimeSpan Timer { get; set; }

        #endregion Fields + Properties

        #region Methods

        public static bool operator !=(Timing timing1, Timing timing2)
        {
            return !timing1.Equals(timing2);
        }

        public static bool operator ==(Timing timing1, Timing timing2)
        {
            return timing1.Equals(timing2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Timing))
                return false;

            return Equals((Timing)obj);
        }

        public bool Equals(Timing other)
        {
            if (Date != other.Date || Timer != other.Timer)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode() ^ Timer.GetHashCode();
        }

        #endregion Methods
    }
}
