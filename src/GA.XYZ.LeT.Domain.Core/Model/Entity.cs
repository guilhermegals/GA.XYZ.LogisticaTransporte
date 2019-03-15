using FluentValidation;
using FluentValidation.Results;
using System;

namespace GA.XYZ.LeT.Domain.Core.Model{

    public abstract class Entity<TEntity> : AbstractValidator<TEntity> where TEntity : Entity<TEntity>{

        #region [Propriedades]

        public Guid Id { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; }

        #endregion

        #region [Métodos]

        public abstract bool IsValid();

        protected Entity() {
            this.ValidationResult = new ValidationResult();
        }

        #endregion
    }
}
