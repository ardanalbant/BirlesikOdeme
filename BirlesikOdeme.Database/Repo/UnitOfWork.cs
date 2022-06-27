using BirlesikOdeme.Database;
using BirlesikOdeme.Database.Repo;
using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Transactions;

namespace BBirlesikOdeme.Database.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseModelEntities context = new DatabaseModelEntities();
        private Repository<customer> _RepositoryCUSTOMER;

        #region Override Methods
        private bool disposed = false;
        public void Save()
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                try
                {
                    context.SaveChanges();
                    tScope.Complete();
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        sb.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            sb.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                        }
                    }

                    throw new Exception(sb.ToString(), ex);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

#       region Table Repo Definitions
        public Repository<customer> RepositoryCUSTOMER
        {
            get
            {
                if (_RepositoryCUSTOMER == null)
                    _RepositoryCUSTOMER = new Repository<customer>(context);
                return _RepositoryCUSTOMER;
            }
        }        
        #endregion
    }
}