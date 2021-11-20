using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern;
using Xunit;

namespace Ecommerce.Test.Features
{
    public class BusinessFeatureShould
    {
        [Fact]
        public void RegisterWithUserAsOwner()
        {
            /* Arrange */
            // Object models
            User user = new("tooensure@gmail.com", "passwordForHash") { FirstName = "Shawn", LastName = "Doe", Username = "shaawndoe", Token = "1234" };
            Business business = new(user) { Name = "tooensure llc", Username = "tooensure" };
            // Mocking DbSet allows implementation of DbSet at runtime
            var mockDbContext = new Mock<DataContext>();
            var mockDbSet = new Mock<DbSet<Business>>();
            var uow = new UnitOfWork(mockDbContext.Object);

            mockDbContext.Setup(x => x.Businesses).Returns(mockDbSet.Object);
            mockDbContext.Setup(p => p.Set<Business>()).Returns(mockDbSet.Object);
            mockDbContext.Setup(p => p.Add(It.IsAny<Business>())).Returns(mockDbSet.Object.Add);

            uow.Businesses.Add(business);

            mockDbSet.Verify(m => m.Add(It.IsAny<Business>()), Times.Once());
            mockDbContext.Verify(m => m.SaveChanges(), Times.Exactly(3));
        }
    }
}
