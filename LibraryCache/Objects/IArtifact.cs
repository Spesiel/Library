namespace Library.Cache.Objects
{
    public interface IArtifact
    {
        #region Methods

        bool Equals(object value);

        int GetHashCode();

        #endregion Methods
    }
}
