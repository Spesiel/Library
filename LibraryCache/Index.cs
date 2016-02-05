using Library.Resources;
using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Diagnostics;

namespace Library.Cache
{
    public static class Index
    {
        //FIXME Fix path
        private static PersistentDictionary<Guid, string> _Library = new PersistentDictionary<Guid, string>(Constants.CachePath + "Index");

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
    }
}