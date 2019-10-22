using System;
using System.Collections.Generic;
using System.Text;
using SchoolModel.Data.Contracts;

namespace SchoolModel.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext ctx ;
        public UnitOfWork(AppDbContext context)
        {
            ctx = context;
        }

        private StudentDao studentDao;
        public StudentDao StudentDao
        {
            get
            {
                if (studentDao == null)
                    studentDao = new StudentDao(ctx);
                return studentDao;
            }
        }



        public void Save()
        {
            ctx.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
