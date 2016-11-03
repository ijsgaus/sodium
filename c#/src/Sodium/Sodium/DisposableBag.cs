using System;
using System.Collections.Generic;

namespace Sodium
{
    internal class DisposableBag : IDisposable
    {
        private readonly List<IDisposable> list = new List<IDisposable>();

        public void Add(IDisposable disposable)
        {
            lock (list)
            {
                list.Add(disposable);    
            }
        }

        public void Dispose()
        {
            lock (list)
            {
                foreach (var disposable in list)
                {
                    disposable.Dispose();
                }
                list.Clear();
            }
        }
    }
}