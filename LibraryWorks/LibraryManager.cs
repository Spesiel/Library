using Library.Cache;
using Library.Resources;
using Library.Resources.Objects;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library.Works
{
    public static class LibraryManager
    {
        #region Fields + Properties

        private static int _NumberOfMediasLoaded;

        #endregion Fields + Properties

        #region Methods

        public static int[] CheckForUpdates()
        {
            int[] ans = new int[2];

            // We got the library loaded, now we should check its integrity
            List<string> mediasOnDisk = GetListMediasInInitialDirectory().ConvertAll(s => s.Replace(AtRuntime.Settings.Folder, ""));
            //// Lists the medias missing in the library (aka New content)
            List<string> newContent = mediasOnDisk.Except(CacheManager.Items.Keys).ToList().ConvertAll(s => s.Insert(0, AtRuntime.Settings.Folder));
            ans[0] = newContent.Count;
            Add(null, newContent);
            //// Lists the medias missing in the initial directory (aka Missing content)
            List<string> missingContent = mediasOnDisk.Except(CacheManager.Items.Keys).ToList();
            ans[1] = missingContent.Count;
            Remove(missingContent);

            return ans;
        }

        /// <summary>
        /// Loads the available library
        /// </summary>
        public static void Load()
        {
            AtRuntime.Settings = new Settings(null);

            using (FileStream file = File.OpenRead(Constants.SettingsFile))
            {
                var deserializer = new DataContractSerializer(typeof(Settings));
                using (var reader = new XmlTextReader(file))
                {
                    AtRuntime.Settings = deserializer.ReadObject(reader) as Settings;
                }
            }
        }

        /// <summary>
        /// Loads the pics details into memory
        /// </summary>
        /// <param name="fullpath">The path in which the photos are located</param>
        public static void LoadDirectory(BackgroundWorker worker, string initialDirectory)
        {
            // Initializes the objects used
            AtRuntime.Settings = new Settings(initialDirectory);
            CacheManager.Clear();

            // Listing the medias
            List<string> medias = GetListMediasInInitialDirectory();
            _NumberOfMediasLoaded = medias.Count;

            // For each media found
            Add(worker, medias);

            // Lists ignored files
            AtRuntime.Settings.SetIgnored(Directory.EnumerateFiles(AtRuntime.Settings.Folder, "*", SearchOption.AllDirectories).
                 Where(file => !Constants.AllowedExtensionsImages.Any(file.ToUpperInvariant().EndsWith)).
                 Where(file => !Constants.AllowedExtensionsVideos.Any(file.ToUpperInvariant().EndsWith)).
                 ToList());
        }

        /// <summary>
        /// Saves the library to its own files<br/>
        /// The file then contains the initialDir and the list of files
        /// </summary>
        public static void Save()
        {
            // Delete the existing library file
            if (File.Exists(Constants.SettingsFile)) File.Delete(Constants.SettingsFile);

            // Serialize and saves the library
            using (FileStream file = File.Create(Constants.SettingsFile))
            {
                var serializer = new DataContractSerializer(typeof(Settings));
                using (var writer = new XmlTextWriter(file, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    serializer.WriteObject(writer, AtRuntime.Settings);
                    writer.Flush();
                }
            }

            // Dispose of the cache
            CacheManager.Flush();
        }

        /// <summary>
        /// Add medias to the cache
        /// </summary>
        /// <param name="worker">a background worker to report progress to</param>
        /// <param name="medias">the list of medias to add to the library</param>
        private static void Add(BackgroundWorker worker, List<string> medias)
        {
            Parallel.ForEach(medias, Constants.ParallelOptions,
                current =>
                {
                    // Add it to the library
                    string file = current.Replace(AtRuntime.Settings.Folder, "");
                    CacheManager.Items.Add(file, new Item());
                    Queuing.Add(file);

                    // Report progress made
                    if (worker != null)
                    {
                        lock (new object()) { worker.ReportProgress(100 * CacheManager.Items.Count / _NumberOfMediasLoaded); };
                    }
                });
        }

        /// <summary>
        /// Lists the medias existing in the initial directory
        /// </summary>
        /// <returns>The list of all medias in the initial directory</returns>
        private static List<string> GetListMediasInInitialDirectory() =>
            Directory.EnumerateFiles(AtRuntime.Settings.Folder, "*", SearchOption.AllDirectories).
                Where(file =>
                Constants.AllowedExtensionsImages.Any(file.ToUpperInvariant().EndsWith) ||
                Constants.AllowedExtensionsVideos.Any(file.ToUpperInvariant().EndsWith)).
                ToList();

        /// <summary>
        /// Remove medias to the cache
        /// </summary>
        /// <param name="medias">the list of medias to remove from the library</param>
        private static void Remove(List<string> medias)
        {
            Parallel.ForEach(medias, Constants.ParallelOptions,
                current =>
                {
                    // Remove it to the library
                    CacheManager.Remove(current.Replace(AtRuntime.Settings.Folder, ""));
                });
        }

        #endregion Methods
    }
}
