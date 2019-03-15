using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GA.XYZ.LeT.Domain.Core.Model;
using GA.XYZ.LeT.Domain.Interfaces;
using GA.XYZ.LeT.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GA.XYZ.LeT.Infra.Data.Repositories {

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>{

        protected LeTContext Context;
        protected DbSet<TEntity> DbSet;

        public Repository(LeTContext context) {

            this.Context = context;
            DbSet = this.Context.Set<TEntity>();

        }

        public virtual void Add(TEntity entity) {

            DbSet.Add(entity);

        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) {

            return DbSet.AsNoTracking().Where(predicate);

        }

        public virtual IEnumerable<TEntity> GetAll() {

            return DbSet.ToList();

        }

        public virtual TEntity GetById(Guid id) {

            return DbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

        }

        public virtual void Remove(Guid id) {

            DbSet.Remove(DbSet.Find(id));

        }

        public int SaveChanges() {
            return Context.SaveChanges();
        }

        public virtual void Update(TEntity entity) {
            DbSet.Update(entity);
        }

        public void Dispose() {
            Context.Dispose();
        }
    }
}
