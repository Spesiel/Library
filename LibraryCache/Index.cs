using System;
using System.Diagnostics;
using System.Linq;

namespace Library.Cache
{
    public class Index : Cache<Guid, string>
    {
        public Index() : base(nameof(Index))
        {
        }

        internal void Register()
        {
            Thumbnails.ObjectAdded += (args) =>
            {
                if (args.IsNew)
                {
                    Library.Add(Guid.NewGuid(), args.File);
                }
                Debug.WriteLine("CACHE.INDEX: Trigger ObjectAdded was fired for file " + args.File);
            };

            Thumbnails.ObjectRemoved += (args) =>
            {
                Library.Where(l => l.Value.Equals(args.File)).AsParallel().ForAll(o => Library.Remove(o.Key));
                Debug.WriteLine("CACHE.INDEX: Trigger ObjectRemoved was fired for file " + args.File);
            };
        }
    }
}