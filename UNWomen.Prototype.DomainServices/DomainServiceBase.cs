#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UNWomen.Common;
using UNWomen.Prototype.Data;

#endregion

namespace UNWomen.Prototype.DomainServices
{
    public class DomainServiceBase : DomainServiceBase<PrototypeContext>
    {
        #region C'tors

        public DomainServiceBase(PrototypeContext dbContext) : base(dbContext)
        {
        }

        #endregion
    }
}