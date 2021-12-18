using System.Collections.Generic;
using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetAllskills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
        
    }
}