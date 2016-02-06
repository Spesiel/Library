using System;

namespace Library.Cache.Objects
{
    [Serializable]
    public struct Person
    {
        #region Fields + Properties

        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion Fields + Properties

        #region Methods

        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person))
                return false;

            return Equals((Person)obj);
        }

        public bool Equals(Person other)
        {
            if (FirstName != other.FirstName || LastName != other.LastName)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }

        #endregion Methods
    }
}
