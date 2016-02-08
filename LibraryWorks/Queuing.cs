using Library.Cache;
using Library.Cache.Objects;
using Penelope.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;

namespace Library.Works
{
    public static class Queuing
    {
        #region Fields + Properties

        public static BackgroundWorker BackgroundWorker { get { return _Worker; } }
        public static ReadOnlyCollection<string> Queue { get { return _Queue.Queue; } }
        private static FirstInFirstOut<string> _Queue = new FirstInFirstOut<string>();
        private static BackgroundWorker _Worker = new BackgroundWorker();

        #endregion Fields + Properties

        #region Methods

        static Queuing()
        {
            _Queue.Added += (s, args) =>
            {
                if (!BackgroundWorker.IsBusy)
                {
                    BackgroundWorker.RunWorkerAsync();
                }
            };

            BackgroundWorker.DoWork += (s, args) =>
            {
                // Get the next item from the queue
                string key = _Queue.Dequeue();
                Item item = CacheManager.Items[key];

                // Perform whatever work there is to do on it
                Treatment.GenerateThumbnail(Color.Transparent, key);

                // Saves the modified item
                CacheManager.Items[key] = item;
            };

            BackgroundWorker.RunWorkerCompleted += (s, args) =>
            {
                if (_Queue.Count > 0)
                {
                    BackgroundWorker.RunWorkerAsync();
                }
            };
        }

        #endregion Methods
    }
}
