using Library.Resources;
using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Diagnostics;

namespace Library.Cache
{
    internal static class Index
    {
        private static PersistentDictionary<Guid, string> _Library = new PersistentDictionary<Guid, string>(path);

        //FIXME Fix path
        private static string path = Constants.CachePath + "Index";

        internal static void Register()
        {
            Thumbnails.ObjectAdded += (args) =>
            {
                if (args.IsNew)
                {
                    _Library.Add(Guid.NewGuid(), args.File);
                }
                Debug.WriteLine("CACHE.INDEX: Trigger ObjectAdded was fired for file " + args.File);
            };
        }

        #region Flush / Clear

        internal static void Clear()
        {
            Flush();
            _Library.Dispose();
            PersistentDictionaryFile.DeleteFiles(path);
            _Library = new PersistentDictionary<Guid, string>(path);
        }

        internal static void Flush()
        {
            _Library.Flush();
        }

        #endregion Flush / Clear
    }
}