using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GA.XYZ.LeT.Domain.Core.Model;

namespace GA.XYZ.LeT.Domain.Interfaces {

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>{

        void Add(TEntity entity); //Adicionar

        TEntity GetById(Guid id); //Pegar pelo ID

        IEnumerable<TEntity> GetAll(); //Pegar todos

        void Update(TEntity entity); //Atualizar a entidade

        void Remove(Guid id); //Remover a entidade

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate); //Buscar a entidade

        int SaveChanges(); //Salvar as alterações


    }
}
