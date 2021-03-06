﻿using Library.Cache;
using Library.Resources.Objects;
using Penelope.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Library.Works
{
    internal static class Queuing
    {
        #region Fields + Properties

        public static BackgroundWorker BackgroundWorker => _Worker;
        private static FirstInFirstOut<string> _Queue = new FirstInFirstOut<string>();
        private static BackgroundWorker _Worker = new BackgroundWorker();

        #endregion Fields + Properties

        #region Constructor

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1810:InitializeReferenceTypeStaticFieldsInline",
            Justification =
            "Necessary in this situation, as we want the events to be initialized right off the bat")]
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
                BackgroundWorker.ReportProgress(100 * _Queue.Count / _Queue.PeakCount);
            };

            BackgroundWorker.RunWorkerCompleted += (s, args) =>
            {
                if (_Queue.Count > 0)
                {
                    BackgroundWorker.RunWorkerAsync();
                }
            };
        }

        #endregion Constructor

        #region Methods: Add/Remove

        public static void Add(string file)
        {
            _Queue.Enqueue(file);
        }

        public static void Remove(string file)
        {
            _Queue.Remove(file);
        }

        #endregion Methods: Add/Remove
    }
}
