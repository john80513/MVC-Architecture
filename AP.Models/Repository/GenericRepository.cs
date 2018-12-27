using AP.Models.Interface;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace AP.Models.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get; set; }
        private DbContext _context { get; set; }

        //public GenericRepository()
        //    : this(new NEC_ATM_FACE_APEntities())
        //{
        //}

        //public GenericRepository(string whichDB)
        //    : this(new NEC_ATM_FACE_APEntities()
        //         , new NEC_ATM_FACE_FETEntities()
        //         , new NEC_ATM_FACE_PHOEntities()
        //         , whichDB)
        //{
        //}

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this._context = context;
        }

        // whichDB：AP、FET、PHO
        public GenericRepository(DbContext context1, DbContext context2, DbContext context3, string whichDB)
        {
            if (context1 == null || context2 == null || context3 == null)
            {
                throw new ArgumentNullException("context");
            }

            if (whichDB == "FET")
            {
                this._context = context2;
            }
            else if(whichDB == "PHO")
            {
                this._context = context3;
            }
            else
            {
                this._context = context1;
            }

        }

        public GenericRepository(ObjectContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this._context = new DbContext(context, true);
        }



        /// <summary>
        /// Creates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="System.ArgumentNullException">instance</exception>
        public void Create(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Set<TEntity>().Add(instance);
                this.SaveChanges();
            }

        }

        /// <summary>
        /// Updates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="keyValues">The key values.</param>
        /// <exception cref="System.ArgumentNullException">instance</exception>
        public void Update(TEntity instance, params object[] keyValues)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            var entry = _context.Entry<TEntity>(instance);

            if (entry.State == EntityState.Detached)
            {
                var set = _context.Set<TEntity>();

                TEntity attachedEntity = set.Find(keyValues);

                if (attachedEntity != null)
                {
                    var attachedEntry = _context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(instance);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
            this.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Entry(instance).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this._context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return this._context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return this._context.Set<TEntity>().AsQueryable();
        }


        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }
    }
}
