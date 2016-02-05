using System;
using System.IO;

namespace Library.Resources
{
    /// <summary>
    /// Contains all the fixed elements used through the application
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Path to the folder containing the Cache
        /// </summary>
        public static readonly string CachePath = BasePath + Properties.CacheNamePrefix + Path.DirectorySeparatorChar;

        /// <summary>
        /// Path to the file containing the Settings
        /// </summary>
        public static readonly string SettingsFile = BasePath + Properties.SettingsFile;

        /// <summary>
        /// The base path for all the files
        /// </summary>
        //FIXME Change the base folder path
        private static readonly string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar;
    }
}