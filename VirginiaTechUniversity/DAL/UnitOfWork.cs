using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirginiaTechUniversity.Models;

namespace VirginiaTechUniversity.DAL
{
    public class UnitOfWork: IDisposable
    {

        private SchoolContext context = new SchoolContext();
        private GenericRepository<Student> studentRepository;

        public GenericRepository<Student> StudentRepository 
        {
            get
            {
                if (this.studentRepository == null) this.studentRepository = new GenericRepository<Student>(this.context);
                return this.studentRepository;
            }
        }

        public void Save() => context.SaveChanges();


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}