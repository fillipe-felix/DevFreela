using System;

namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description, DateTime createdAt)
        {
            Description = description;
            CreatedAt = createdAt;
        }
        
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}