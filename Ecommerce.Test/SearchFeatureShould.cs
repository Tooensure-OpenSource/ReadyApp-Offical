using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Moq;
using Tooensure.DataStructure.RepositoryPattern;
using Tooensure.DataStructure.RepositoryPattern.Repositorties;
using Xunit;

namespace Ecommerce.Test
{
    public class SearchFeatureShould
    {
        public User User { get; set; }
        [Fact]
        public void ValidateSearchInput()
        {
            // System Under Test
            // Arrange
            SearchFeature sut1 = new("ImNotEmpty");
            SearchFeature sut2 = new("");
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            SearchFeature sut3 = new(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.



            // Act
            bool ValidValidation1 = sut1.IsValid;
            bool FalseValidation1 = sut2.IsValid;
            bool FalseValidation2 = sut3.IsValid;


            // Assert
            Assert.True(ValidValidation1);
            Assert.False(FalseValidation1);
            Assert.False(FalseValidation2);

        }
    }
}