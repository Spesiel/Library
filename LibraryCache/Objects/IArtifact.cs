namespace Library.Cache.Objects
{
    public interface IArtifact
    {
        #region Methods

        bool Equals(object obj);

        int GetHashCode();

        #endregion Methods
    }
}
