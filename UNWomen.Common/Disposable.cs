#region

using System;

#endregion

namespace UNWomen.Common
{
    public class Disposable : IDisposable
    {
        #region Fields

        private bool _isDisposed;

        #endregion

        #region Destructors

        ~Disposable()
        {
            Dispose(false);
        }

        #endregion

        #region Instance Methods

        protected virtual void DisposeCore()
        {
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}