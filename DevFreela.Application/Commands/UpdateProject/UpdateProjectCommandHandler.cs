using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly DevFreelaDbContext _dbContext;

        public UpdateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Update(project.Title, project.Description, project.TotalCost);

            await _dbContext.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}