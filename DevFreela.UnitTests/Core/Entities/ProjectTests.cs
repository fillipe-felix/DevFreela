using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectIfProjectStartWorks()
        {
            var project = new Project("Nome de Teste", "Descrição de Teste", 1, 2, 10000);

            Assert.Equal(ProjectStatus.Created, project.Status);
            Assert.Null(project.StartedAt);
            
            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);
            
            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);
            
            project.Start();

            Assert.Equal(ProjectStatus.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}