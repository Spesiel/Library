using System;

namespace Library.Cache
{
    internal delegate void AsyncQueueEventHandler(QueueEventAsyncArgs arg);

    internal class QueueEventAsyncArgs : EventArgs
    {
    }
}
