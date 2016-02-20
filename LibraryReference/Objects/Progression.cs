using Library.Resources.TextResources;

namespace Library.Resources.Objects
{
    public struct Progression : IArtifact
    {
        #region Fields + Properties

        public int Current { get; set; }
        public int Percentage => 100 * Current / Total;
        public string Progress => Current + TextsPermanent.CountSeparator + Total;
        public string ProgressPercentage => Percentage + TextsPermanent.PercentSign;
        public int Total { get; set; }

        #endregion Fields + Properties

        #region Methods

        public static bool operator !=(Progression timing1, Progression timing2) => !timing1.Equals(timing2);

        public static bool operator ==(Progression timing1, Progression timing2) => timing1.Equals(timing2);

        public override bool Equals(object obj)
        {
            if (!(obj is Progression))
                return false;

            return Equals((Progression)obj);
        }

        public bool Equals(Progression other)
        {
            if (Current != other.Current || Total != other.Total)
                return false;

            return true;
        }

        public override int GetHashCode() => Current.GetHashCode() ^ Total.GetHashCode();

        #endregion Methods
    }
}
