using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool IsDisposed;
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        private void Dispose(bool disposing)
        {
            if(!IsDisposed && disposing)
            {
                DisposeCore();
            }
            IsDisposed = true;

        }
        //overwrite this dispose custom object
        protected virtual void DisposeCore()
        {

        }
        //private void Dispose(bool v)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
