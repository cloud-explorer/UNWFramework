#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using UNWomen.Common;
using UNWomen.Common.Contracts;

#endregion

namespace UNWomen.Prototype.Client.Entities
{
    public abstract class ClientEntity<T> : EntityBase
        where T : IEntityBase
    {
        public ClientEntity()
        {
            ValidationErrors = null;
            _Validator = GetValidator();
            Validate();
        }

        #region Fields

        protected IValidator _Validator = null;
        private string _error;

        #endregion

        #region Instance Properties

        public virtual T Data { get; set; }

        #endregion

        #region Validation

        protected abstract IValidator GetValidator();

        public IEnumerable<ValidationFailure> ValidationErrors { get; private set; }

        public void Validate()
        {
            if (_Validator != null)
            {
                ValidationResult results = _Validator.Validate(this);
                ValidationErrors = results.Errors;
            }
        }

        public virtual bool IsValid
        {
            get { return ValidationErrors == null || !ValidationErrors.Any(); }
        }

        #endregion

    }
}