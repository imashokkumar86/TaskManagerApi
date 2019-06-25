using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using UnitTests.DataAccess.Helpers;
using Moq;
using Xunit;
namespace UnitTests.DataAccess
{
    public class ProjectManagerApiDbContextTests
    {
        [Fact]
        public void ToVerifyModelCreationWorksOrNot()
        {
            var mockModel = new Mock<ModelBuilder>(new ConventionSet());
            try
            {
                var contextOptions = new DbContextOptions<ProjectManagerApiDbContextStub>();
                var projectManagerDbContextStub = new ProjectManagerApiDbContextStub(contextOptions);
                var modelBuilder = new ModelBuilder(new ConventionSet());
                var model = new Model();
                var configSource = new ConfigurationSource();

                var internalModelBuilder = new InternalModelBuilder(model);

                var taskdetail = new TaskDetail();

                var entity = new EntityType("TaskModel", model, configSource);
                var internalEntityTypeBuilder = new InternalEntityTypeBuilder(entity, internalModelBuilder);
                var entityTypeBuilder = new EntityTypeBuilder<TaskDetail>(internalEntityTypeBuilder);
                mockModel.Setup(m => m.Entity<TaskDetail>()).Returns(entityTypeBuilder);
                var property = new Property("Name", taskdetail.GetType(), taskdetail.GetType().GetProperty("Name"), taskdetail.GetType().GetField("Name"), entity, configSource, null);
                var internalPropertyBuilder = new InternalPropertyBuilder(property, internalModelBuilder);
                var propertyBuilder = new PropertyBuilder<string>(internalPropertyBuilder);

               
                projectManagerDbContextStub.ModelCreation(modelBuilder);
            }
            catch (Exception ex)
            {
                mockModel.Verify(m => m.Entity<TaskDetail>().HasKey("Id"), Times.Once);
               
                Assert.NotNull(ex);
            }
        }
    }


}
