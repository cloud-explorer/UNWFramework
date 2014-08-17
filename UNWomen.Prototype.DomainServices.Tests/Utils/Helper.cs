#region

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using Ploeh.AutoFixture;

#endregion

namespace UNWomen.Prototype.DomainServices.Tests.Utils
{
    public static class Helper
    {
        public static T CreateAutoFilledObject<T>(this Fixture fixture)
            where T : class
        {
            T foo = fixture.Create<T>();
            return foo;
        }

        #region Class Methods

        public static Mock<List<T>> CreateListMoq<T>(this Fixture fixture, int count = 10)
            where T : class
        {
            var objs = new List<T>();
            for (int i = 0; i < count; i++)
            {
                var moq = fixture.Create<T>();
                objs.Add(moq);
            }
            var mocks = new Mock<List<T>>();
            fixture.Inject(mocks.Object);
            return mocks;
        }

        public static Mock<DbSet<T>> CreateManyMoqDbSet<T>(this Fixture fixture, int count = 10)
            where T : class
        {
            IQueryable<T> data = fixture.CreateMany<T>(count).AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }

        public static Mock<T> CreateMoq<T>(this Fixture fixture)
            where T : class
        {
            var mock = new Mock<T>();
            fixture.Inject(mock.Object);
            return mock;
        }

        #endregion
    }
}