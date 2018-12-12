using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library;
using Project0.DataAccess;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace Project0.Tests
{
    public class DataRepositoryTests
    {
        [Fact]
        public void SavingChangesWithNothingDoesntThrowException()
        {
            // arrange
            var options = new DbContextOptionsBuilder<Project0Context>().UseInMemoryDatabase("no_changes_test").Options;
            using (var db = new Project0Context(options))
            {
                //nothing
            }

            // act
            using (var db = new Project0Context(options))
            {
                var repo = new DataRepository(db);
                repo.Save();
            }

            // assert
            // (no exception should have been thrown)
        }
    }
}
