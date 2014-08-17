#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using UNWomen.Prototype.Data;
using UNWomen.Prototype.DomainServices.Tests.Utils;
using UNWomen.Prototype.Entities;

#endregion

namespace UNWomen.Prototype.DomainServices.Tests
{
    [TestClass]
    public class MovieServiceTests
    {
        #region Readonly & Static Fields

        private static readonly Fixture _fixture = new Fixture();

        #endregion

        #region Fields

        private Mock<PrototypeContext> _mockContext;

        #endregion

        #region Instance Methods

        [TestMethod]
        public void GetMovie_gets_the_correct_movie()
        {
            //Arrange
            Mock<DbSet<Movie>> mockSet = _fixture.CreateManyMoqDbSet<Movie>(5);
            _mockContext.Setup(c => c.Movies).Returns(mockSet.Object);
            int movieId = mockSet.Object.OrderBy(r => Guid.NewGuid()).First().MovieId;
            var service = new MovieService(_mockContext.Object);

            //Act
            Movie movie = service.GetMovie(movieId);

            //Assert
            Assert.AreEqual(movieId, movie.MovieId);
        }

        [TestMethod]
        public void CreateMovie_calls_dbset_add_and_saves_changes_to_context()
        {
            //Arrange
            Movie movieToBeAdded = _fixture.CreateAutoFilledObject<Movie>();
            Mock<DbSet<Movie>> mockSet = _fixture.CreateManyMoqDbSet<Movie>(5);
            _mockContext.Setup(c => c.Movies)
                        .Returns(mockSet.Object);
            var service = new MovieService(_mockContext.Object);

            //Act
            service.CreateMovie(movieToBeAdded);

            //Assert
            mockSet.Verify(m => m.Add(It.IsAny<Movie>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void DeleteMovie_calls_dbset_remove_and_saves_changes_to_context()
        {
            //Arrange
            Mock<DbSet<Movie>> mockSet = _fixture.CreateManyMoqDbSet<Movie>(5);
            Movie movieToBeDeleted = mockSet.Object.OrderBy(r => Guid.NewGuid()).First();
            _mockContext.Setup(c => c.Movies)
                        .Returns(mockSet.Object);
            var service = new MovieService(_mockContext.Object);

            //Act
            service.DeleteMovie(movieToBeDeleted);

            //Assert
            mockSet.Verify(m => m.Remove(It.IsAny<Movie>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void UpdateMovie_calls_dbset_remove_and_saves_changes_to_context()
        {
            //Arrange
            Mock<DbSet<Movie>> mockSet = _fixture.CreateManyMoqDbSet<Movie>(5);
            Movie movieToBeDeleted = mockSet.Object.OrderBy(r => Guid.NewGuid()).First();
            _mockContext.Setup(c => c.Movies)
                        .Returns(mockSet.Object);
            var service = new MovieService(_mockContext.Object);

            //Act
            service.DeleteMovie(movieToBeDeleted);

            //Assert
            mockSet.Verify(m => m.Remove(It.IsAny<Movie>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        #endregion

        #region Class Methods

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _fixture.Customize(new IgnoreVirtualMembersCustomization());
        }

        [TestInitialize]
        public void TestSetup()
        {
            _mockContext = new Mock<PrototypeContext>();
        }

        #endregion
    }
}