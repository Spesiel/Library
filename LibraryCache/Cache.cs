using Library.Resources;
using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Cache
{
    public abstract class Cache<TKey, TValue> : IDisposable where TKey : IComparable<TKey>
    {
        #region Fields + Properties

        protected IList<TKey> Keys { get { return _Library.Keys.OrderBy(k => k).ToList(); } }
        protected PersistentDictionary<TKey, TValue> Library { get { return _Library; } }
        private PersistentDictionary<TKey, TValue> _Library;

        #endregion Fields + Properties

        #region Indexers

        public TValue this[int index]
        {
            get
            {
                return Library[Keys[index]];
            }
            set
            {
                Library[Keys[index]] = value;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return Library[key];
            }
            set
            {
                Library[key] = value;
            }
        }

        #endregion Indexers

        #region Methods

        public void Add(TKey key, TValue value)
        {
            if (Library.ContainsKey(key))
            {
                Library[key] = value;
            }
            else
            {
                Library.Add(key, value);
            }
        }

        public IEnumerable<TValue> Get(string file)
        {
            return Library.Where(l => CacheManager.Catalog.GetGuids(file).Any().Equals(l.Key)).Select(i => i.Value);
        }

        internal virtual void Remove(TKey key)
        {
            Library.Remove(key);
        }

        #endregion Methods

        #region Constructors

        internal Cache(string path)
        {
            _Library = new PersistentDictionary<TKey, TValue>(Constants.CachePath + path);
        }

        private Cache()
        {
        }

        #endregion Constructors

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
                    Flush();
                }

                _Library = null;

                disposedValue = true;
            }
        }

        #endregion IDisposable Support
    }
}
