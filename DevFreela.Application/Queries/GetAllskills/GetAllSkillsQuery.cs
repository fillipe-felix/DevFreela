using System.Collections.Generic;
using DevFreela.Core.DTOs;
using MediatR;

namespace DevFreela.Application.Queries.GetAllskills
{
    public class GetAllSkillsQuery : IRequest<List<SkillDto>>
    {
        
    }
}