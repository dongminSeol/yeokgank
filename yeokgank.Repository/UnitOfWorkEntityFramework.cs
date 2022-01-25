using System;
using System.Collections.Generic;
using System.Text;
using yeokgank.Repository.Usermaster.Command;

namespace yeokgank.Repository
{
    public class UnitOfWorkEntityFramework : IUnitOfWorkEntityFramework
    {
        private readonly yeokgankDbContext _context;
        public IUserMasterCommand UserMasterCommand { get;}
        public UnitOfWorkEntityFramework(yeokgankDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            bool result = true;
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbTransaction.Commit();
                }
                catch(Exception e)
                {
                    dbTransaction.Rollback();
                    result = false;
                }
            }

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            
        }
        private bool disposedValue = false; //중복호출체크
        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue) return;

            if (disposing)
            {
                _context.Dispose();
            }

            disposedValue = true;

        }
    }
}
