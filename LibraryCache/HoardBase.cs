using Library.Cache.Objects;
using Library.Resources;
using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Cache
{
    public abstract class HoardBase<TKey, TValue> : IDisposable where TKey : IComparable<TKey>
    {
        #region Fields + Properties

        public int Count { get { return Library.Count; } }
        public IList<TKey> Keys { get { return _Library.Keys.OrderBy(k => k).ToList(); } }
        public PersistentDictionary<TKey, TValue> Library { get { return _Library; } }
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

        public IEnumerable<IArtifact> Get(IEnumerable<TKey> keys)
        {
            return Library.Where(l => l.Key.Equals(keys.Any())).Select(i => i.Value as IArtifact);
        }

        internal virtual void Remove(TKey key)
        {
            Library.Remove(key);
        }

        #endregion Methods

        #region Constructors

        internal HoardBase(string path)
        {
            _Library = new PersistentDictionary<TKey, TValue>(Constants.CachePath + path);
        }

        private HoardBase()
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
