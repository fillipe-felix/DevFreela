using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillDto>> GetAllAsync()
        {
            var skills = await _dbContext.Skills.ToListAsync();

            var skillDto = skills.Select(p => new SkillDto(p.Id, p.Description));

            return skillDto.ToList();
        }
    }
}