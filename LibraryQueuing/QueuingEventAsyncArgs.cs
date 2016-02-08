using System;

namespace Library.Queuing
{
    internal delegate void AsyncQueuingEventHandler(QueuingEventAsyncArgs arg);

    internal class QueuingEventAsyncArgs : EventArgs
    {
    }
}
