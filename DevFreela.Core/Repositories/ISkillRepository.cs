using System.Collections.Generic;
using System.Threading.Tasks;
using DevFreela.Core.DTOs;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<SkillDto>> GetAllAsync();
    }
}