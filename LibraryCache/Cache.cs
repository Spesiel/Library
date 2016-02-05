using Library.Resources;
using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Cache
{
    public class Cache<TKey, TValue> : IDisposable where TKey : IComparable<TKey>
    {
        private PersistentDictionary<TKey, TValue> _Library;
        protected IList<TKey> Keys { get { return _Library.Keys.OrderBy(k => k).ToList(); } }
        protected PersistentDictionary<TKey, TValue> Library { get { return _Library; } }

        public Cache(string path)
        {
            _Library = new PersistentDictionary<TKey, TValue>(Constants.CachePath + path);
        }

        private Cache()
        {
        }

        #region Flush / Clear

        internal void Clear()
        {
            string path = _Library.DatabasePath;
            Flush();
            _Library.Dispose();
            PersistentDictionaryFile.DeleteFiles(path);
            _Library = new PersistentDictionary<TKey, TValue>(path);
        }

        internal void Flush()
        {
            _Library.Flush();
        }

        #endregion Flush / Clear

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        #endregion IDisposable Support
    }
}