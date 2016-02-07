using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;

namespace Library.Resources
{
    [DataContract]
    public class Settings
    {
        #region Fields + Properties

        public string GetDirectory { get { return InitialDirectory + Path.DirectorySeparatorChar; } }

        [DataMember(Name = "Ignored")]
        public Collection<string> Ignored { get; internal set; }

        [DataMember(Name = "InitialDirectory")]
        private string InitialDirectory { get; set; }

        #endregion Fields + Properties

        #region Constructors

        public Settings(string initialDirectory)
        {
            this.InitialDirectory = initialDirectory;
            this.Ignored = new Collection<string>();
        }

        #endregion Constructors

        #region Methods

        public string GetFile(string file)
        {
            return GetDirectory + file;
        }

        public void SetIgnored(IList<string> value)
        {
            Ignored = new Collection<string>(value);
        }

        #endregion Methods
    }
}
